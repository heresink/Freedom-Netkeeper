using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace E信自由版.Services
{
    public static class DataFile
    {
        [DataContract]
        public class ImportantData
        {
            [DataMember]
            public UserType EXin { get; set; }
            [DataMember]
            public UserType Router { get; set; }

            public ImportantData()
            {
                this.EXin = new UserType();
                this.Router = new UserType();
            }

            [DataContract]
            public class UserType
            {
                [DataMember]
                public string UserName { get; set; }
                [DataMember]
                public string PassWord { get; set; }
            }

        }

        private static string dataFilePath = Directory.GetCurrentDirectory() + "\\dat";

        public static ImportantData GetImportantData()
        {
            if (!File.Exists(dataFilePath))
                return null;

            StreamReader sr = new StreamReader(dataFilePath);
            string jsonStr = sr.ReadToEnd();
            sr.Close();
            jsonStr = Encryption.Decrypt(jsonStr);          
            ImportantData obj = new ImportantData();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ImportantData));
            using(MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(Encryption.Decrypt(jsonStr))))
            {
                obj = js.ReadObject(ms) as ImportantData;
            }
            return obj;      
        }

        public static void SaveImportantData(ImportantData dat)
        {
            ImportantData id = new ImportantData();
            if (File.Exists(dataFilePath))
                id = GetImportantData();

            if (dat.EXin.UserName != null)
                id.EXin.UserName = dat.EXin.UserName;
            if (dat.EXin.PassWord != null)
                id.EXin.PassWord = dat.EXin.PassWord;

            if (dat.Router.UserName != null)
                id.Router.UserName = dat.Router.UserName;
            if (dat.Router.PassWord != null)
                id.Router.PassWord = dat.Router.PassWord;                                

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(id.GetType());
            string jsonText;

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, id);
                jsonText = Encoding.UTF8.GetString(stream.ToArray());
                jsonText = Encryption.Encrypt(jsonText);
            }

            StreamWriter sw = new StreamWriter(dataFilePath);
            sw.Write(Encryption.Encrypt(jsonText));
            sw.Close();
        }
    }
}
