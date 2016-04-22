using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E信自由版.Services
{
    public enum RouterModel
    {
        WR740N = 0,
        WR703N = 1
    }

    public class Router
    {
        public class GateWay
        {
            public GateWay(string add,bool ping)
            {
                this.address = add;
                this.canPing = ping;
            }
            public string address;
            public bool canPing;
        }

        public class ReturnPara
        {
            public bool accessSuccess = true;
            public string text;
        }

        public Router()
        {

        }
        private const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; rv:11.0) like Gecko";

        public string RouterIP = null; 

        public RouterModel model = 0;

        public ReturnPara GetTextUseHeader(string url, DataFile.ImportantData id)
        {
            ReturnPara rp = new ReturnPara();
            HttpWebResponse response;
            HttpWebRequest request;
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.UserAgent = DefaultUserAgent;
                request.Timeout = 5000;

                request.Referer = "http://" + RouterIP + "/";
                CredentialCache cache = new CredentialCache();
                cache.Add(new Uri(url), "Basic", new NetworkCredential(id.Router.UserName, id.Router.PassWord));
                request.Credentials = cache;

                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                rp.text = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                rp.text = ex.Message;
                rp.accessSuccess = false;
            }
            return rp;
        }

        public ReturnPara GetTextUseCookie(string url, DataFile.ImportantData id)
        {
            HttpWebResponse response;
            HttpWebRequest request;
            ReturnPara rp = new ReturnPara();
            string authorization_str = id.Router.UserName + ":" + id.Router.PassWord;
            string encrypted_Str = Convert.ToBase64String(Encoding.UTF8.GetBytes(authorization_str));
            CookieContainer co = new CookieContainer();
            CookieCollection cc = new CookieCollection();
            cc.Add(new Cookie("Authorization", encrypted_Str, "/", ".192.168.1.1"));
            cc.Add(new Cookie("subType", "pcSub", "/", ".192.168.1.1"));
            cc.Add(new Cookie("ChgPwdSubTag", "", "/", ".192.168.1.1"));
            cc.Add(new Cookie("tLargeScreenP", "1", "/", ".192.168.1.1"));
            co.Add(cc);
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.UserAgent = DefaultUserAgent;
                request.Timeout = 5000;

                request.CookieContainer = co;
                request.Referer = "http://192.168.1.1";

                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                rp.text = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                rp.accessSuccess = false;
                rp.text = ex.Message;
            }
            return rp;
        }

        public static async Task<List<Router.GateWay>> GetGateway()
        {
            List<Router.GateWay> gateWayList = new List<Router.GateWay>();
            NetworkInterface[] networkAdpater = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in networkAdpater)
            {
                if (adapter.NetworkInterfaceType != NetworkInterfaceType.Ethernet && adapter.NetworkInterfaceType != NetworkInterfaceType.Wireless80211)
                    continue;
                if(adapter.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }
                else
                {
                    IPInterfaceProperties ip = adapter.GetIPProperties();              
                    GatewayIPAddressInformationCollection gateways = ip.GatewayAddresses;
                    foreach (var gateWay in gateways)
                    {
                        if (gateWay.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            bool x = await CanPingIP(gateWay.Address.ToString());
                            if (x)
                            {
                                gateWayList.Add(new Router.GateWay(gateWay.Address.ToString(), true));
                            }
                            else
                            {
                                gateWayList.Add(new Router.GateWay(gateWay.Address.ToString(), false));
                            }

                        }
                    }
                }               
            }
            return gateWayList;
        }

        public static async Task<bool> CanPingIP(string ipAddress)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(ipAddress, 1000);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> PPPoE(string ip, DataFile.ImportantData id)
        {
            ReturnPara rp = new ReturnPara();
            string username = id.EXin.UserName;
            string password = id.EXin.PassWord;
            username = Algorithm.Encryption(Encoding.ASCII.GetBytes(username));
            username = username.Substring(0, 21);
            username = Uri.EscapeDataString(username);
            string url = "http://" + ip + "/userRpm/PPPoECfgRpm.htm?wan=0&wantype=2&acc=" + username +
                "&psw=" + password + "&confirm=" + password + "&specialDial=0&SecType=0&sta_ip=0.0.0.0&sta_mask=0.0.0.0&linktype=1&waittime=15&Save=%B1%A3+%B4%E6";
            if(this.model == RouterModel.WR703N)
            {
                rp = this.GetTextUseCookie(url, id);    
            }
            else if(this.model == RouterModel.WR740N)
            {
                rp = this.GetTextUseHeader(url, id);
            }

            if(rp.accessSuccess)
            {
                int count = 0;
                bool setSuccess = false;
                while(!setSuccess)
                {
                    count++;                   
                    setSuccess = await IsRouterInPPPoEStatus(id);
                    if (count == 100)
                    {
                        rp.accessSuccess = false;
                        break;
                    }
                        
                }
                
            }
            return rp.accessSuccess;
            
        }    

        public async Task<bool> IsRouterInPPPoEStatus(DataFile.ImportantData id)
        {
            List<string> wanInfo = GetRouterInfo(id);
            if (wanInfo.Count < 6)
            {
                return false;
            }

            if (wanInfo[5] != "" && wanInfo[1] != "0.0.0.0")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> GetRouterInfo(DataFile.ImportantData id)
        {
            List<string> wanInfo = new List<string>();
            string url = "http://" + this.RouterIP + "/userRpm/StatusRpm.htm";
            ReturnPara rp = new ReturnPara();
            if (this.model == RouterModel.WR703N)
            {
                rp = this.GetTextUseCookie(url, id);
            }
            else if (this.model == RouterModel.WR740N)
            {
                rp = this.GetTextUseHeader(url, id);
            }
            if(rp.accessSuccess)
            {              
                Match status_mc = Regex.Match(rp.text, @"var wanPara([\s\S]*?)\);");
                string data = status_mc.Groups[1].Value.Substring(status_mc.Groups[1].Value.IndexOf('(') + 1);
                MatchCollection info_mc = Regex.Matches(data, @"""([\s\S]*?)""");
                for (int i = 0; i < info_mc.Count - 2; i++)
                {
                    wanInfo.Add(info_mc[i].Groups[1].Value);
                }
            }
            
            return wanInfo;
        }

        public List<string> GetRouterStatus(DataFile.ImportantData id,bool isNotice)
        {
            List<string> status = new List<string>();
            List<string> wanInfo = this.GetRouterInfo(id);
            if(wanInfo.Count < 6)
            {
                if(isNotice)
                    MessageShow.Display("无法获取路由器信息！", "错误");
                return status;
            }
            string connected;
            string display_str;
            display_str = "MAC地址：" + wanInfo[0] +
                "\r\nIP地址：" + wanInfo[1] +
                "\r\n子网掩码：" + wanInfo[2] +
                "\r\n网关：" + wanInfo[3] +
                "\r\nDNS服务器：" + wanInfo[4] +
                "\r\n上网时间：" + wanInfo[5];
            if(wanInfo[5] != "" && wanInfo[1]!="0.0.0.0")
            {
                connected = "True";
            }
            else
            {
                connected = "False";
            }
            status.Add(connected);
            status.Add(display_str);
            return status;
        }

        public async Task<bool> Disconnect(DataFile.ImportantData id)
        {
            string url = "http://192.168.1.1/userRpm/StatusRpm.htm?Disconnect=断 线&wan=1";
            ReturnPara rp = new ReturnPara();
            if(this.model == RouterModel.WR740N)
            {
                rp = this.GetTextUseHeader(url, id);
            }
            else if(this.model == RouterModel.WR703N)
            {
                rp = this.GetTextUseCookie(url, id);
            }

            if (rp.accessSuccess)
            {
                int count = 0;
                bool setSuccess = false;
                while (!setSuccess)
                {
                    count++;
                    setSuccess = !(await IsRouterInPPPoEStatus(id));
                    if (count == 10)
                    {
                        rp.accessSuccess = false;
                        break;
                    }

                }

            }
            return rp.accessSuccess;
        }
    }
}
