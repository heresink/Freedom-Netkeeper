using DotRas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E信自由版.Services
{
    public static class PPPoE
    {
        public static void CreateOrUpdatePPPOE(string updatePPPOEname)
        {
            RasDialer dialer = new RasDialer();
            RasPhoneBook currentUserPhoneBook = new RasPhoneBook();
            string path = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
            currentUserPhoneBook.Open(path);

            if (currentUserPhoneBook.Entries.Contains(updatePPPOEname))
            {
                currentUserPhoneBook.Entries[updatePPPOEname].PhoneNumber = " ";
                currentUserPhoneBook.Entries[updatePPPOEname].Update();
            }         
            else
            {
                string adds = string.Empty;
                ReadOnlyCollection<RasDevice> readOnlyCollection = RasDevice.GetDevices();
                RasDevice device = RasDevice.GetDevices().Where(o => o.DeviceType == RasDeviceType.PPPoE).First();
                RasEntry entry = RasEntry.CreateBroadbandEntry(updatePPPOEname, device);
                entry.PhoneNumber = " ";
                currentUserPhoneBook.Entries.Add(entry);
            }
        }

        public static bool Connect(string connectionName,string userName,string pwd)
        {
            bool connectSuccess = false;
            int count = 0;
            try
            {
                CreateOrUpdatePPPOE(connectionName);
                RasDialer dialer = new RasDialer();
                dialer.EntryName = connectionName;
                dialer.PhoneNumber = " ";
                dialer.AllowUseStoredCredentials = true;
                dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
                dialer.Credentials = new NetworkCredential(userName, pwd);
                dialer.Timeout = 1000;
                RasHandle myras = dialer.Dial();
                while (myras.IsInvalid)
                {
                    count++;
                    if (count == 5)
                        break;
                    Thread.Sleep(1000);
                    myras = dialer.Dial();
                }
                if (!myras.IsInvalid)
                {                  
                    connectSuccess = true;
                }
            }
            catch (Exception ex)
            {
                MessageShow.Display("拨号失败! " + Convert.ToString(DateTime.Now) + " 链接:" + connectionName + "\r\nerror is :: " + ex.ToString());            
            }
            return connectSuccess;
        }

        public static void Disconnect(string connection)
        {
            ReadOnlyCollection<RasConnection> conList = RasConnection.GetActiveConnections();
            foreach (RasConnection con in conList)
            {
                if(con.EntryName == connection)
                    con.HangUp();
            }
        }

        public static bool IsEXinInActive()
        {
            ReadOnlyCollection<RasConnection> conList = RasConnection.GetActiveConnections();
            foreach (RasConnection con in conList)
            {
                if (con.EntryName == "E信自由版")
                    return true;
            }
            return false;
        }
        public static string GetIPAddress(string connectionName)
        {
            string IP;
            StringBuilder sb = new StringBuilder();
            foreach (RasConnection connection in RasConnection.GetActiveConnections())
            {
                if (connection.EntryName == connectionName)
                {
                    RasIPInfo ipAddresses = (RasIPInfo)connection.GetProjectionInfo(RasProjectionType.IP);
                    if (ipAddresses != null)
                    {
                        sb.AppendFormat("客户端IP:{0}\r\n", ipAddresses.IPAddress.ToString());
                        sb.AppendFormat("服务端IP:{0}\r\n", ipAddresses.ServerIPAddress.ToString());
                    }
                }
                sb.AppendLine();
            }
            if (sb.Length == 0)
                IP = "无法获取IP地址！";
            else
                IP = sb.ToString();
            return IP;
        }

    }
}
