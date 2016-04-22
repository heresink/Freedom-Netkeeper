using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace E信自由版.Services
{
    public static class Algorithm
    {
        static string str = "hubtxinli01";    
        public static string Encryption(byte[] userName)
        {
            int i;
            byte[] temp = new byte[32];
            long timeNow,timeDivedByFive;           
            byte[] timeArray = new byte[4];      
            byte[] afterMD5 = new byte[16];
            byte[] beforeMD5 = new byte[128];
            byte[] MD5Array = new byte[2];
            byte[] timeHash = new byte[4]; 
            byte[] PIN27 = new byte[6]; 
            byte[] PIN = new byte[30];
            MD5 md5 = new MD5CryptoServiceProvider();
            string tempStr;
            DateTime time = DateTime.Now;
            timeNow = DateTimeToUnixTimestamp(time);          
            timeDivedByFive = timeNow / 5;
            for(i = 0; i < 4; i++) 
            {
                timeArray[i] = (byte)(timeDivedByFive >> (8 * (3 - i)) & 0xFF);
            }

            Array.Copy(timeArray, 0, beforeMD5, 0, 4);
            Array.Copy(userName,0,beforeMD5,4,11);
            Array.Copy(Encoding.ASCII.GetBytes(str),0,beforeMD5,15,str.Length);                   
            afterMD5 = md5.ComputeHash(beforeMD5, 0, Encoding.ASCII.GetString(beforeMD5).IndexOf('\0'));
            MD5Array[0] = (byte)"0123456789abcdef"[afterMD5[0] >> 4];
            MD5Array[1] = (byte)"0123456789abcdef"[afterMD5[0] & 0xF];
            for(i = 0; i < 32; i++) 
            {
                temp[i] = (byte)(timeArray[(31 - i) / 8] & 1);
                timeArray[(31 - i) / 8] = (byte)(timeArray[(31 - i) / 8] >> 1);
            }
            for (i = 0; i < 4; i++) 
            {
                timeHash[i] = (byte)(temp[i] * 128 + temp[4 + i] * 64 + temp[8 + i]
                    * 32 + temp[12 + i] * 16 + temp[16 + i] * 8 + temp[20 + i]
                    * 4 + temp[24 + i] * 2 + temp[28 + i]);
            }
            temp[1] = (byte)((timeHash[0] & 3) << 4);
            temp[0] = (byte)((timeHash[0] >> 2) & 0x3F);
            temp[2] = (byte)((timeHash[1] & 0xF) << 2);
            temp[1] = (byte)((timeHash[1] >> 4 & 0xF) + temp[1]);
            temp[3] = (byte)(timeHash[2] & 0x3F);
            temp[2] = (byte)(((timeHash[2] >> 6) & 0x3) + temp[2]);
            temp[5] = (byte)((timeHash[3] & 3) << 4);
            temp[4] = (byte)((timeHash[3] >> 2) & 0x3F);
            for (i = 0; i < 6; i++) 
            {
                PIN27[i] = (byte)(temp[i] + 0x020);
                if(PIN27[i]>=0x40) 
                {
                    PIN27[i]++;
                }
            }
            PIN[0] = (byte)'\r';
            PIN[1] = (byte)'\n';
            Array.Copy(PIN27,0,PIN,2,6);
            PIN[8] = MD5Array[0];
            PIN[9] = MD5Array[1];
            Array.Copy(userName,0,PIN,10,userName.Length);          
            tempStr = Encoding.ASCII.GetString(PIN);
            return tempStr;
        }

        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        public static DateTime UnixTimestampToDateTime(this DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddSeconds(timestamp);
        }
    }
}
