using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E信自由版.Services
{
    public static class HttpLink
    {
        public class ReturnPara
        {
            public bool accessSuccess = true;
            public string text;
        }
        private const string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public static ReturnPara Get(string url,bool isNotice)
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

                response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
             
                rp.text = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                if(isNotice)
                {
                    MessageShow.Display(ex.ToString(), "错误");
                }
                
                rp.accessSuccess = false;
            }
            return rp;
        }

    }
}

