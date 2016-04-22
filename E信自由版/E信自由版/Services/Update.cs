using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace E信自由版.Services
{
    public class UpdateCheck
    {
        public UpdateCheck()
        {

        }

        private string XMLPath = System.IO.Directory.GetCurrentDirectory() + "\\app.config.xml";
        private string UpdateUrl = "";

        private void CreateConfigXML()
        {

            XmlTextWriter myXmlTextWriter = new XmlTextWriter(XMLPath, Encoding.UTF8);           
            myXmlTextWriter.Formatting = Formatting.Indented;
            myXmlTextWriter.WriteStartDocument(false);

            myXmlTextWriter.WriteStartElement("Configuration");
            myXmlTextWriter.WriteStartElement("AppSettings");

            myXmlTextWriter.WriteElementString("LastCheckDate", "2016-04-19");
 
            myXmlTextWriter.WriteEndElement();
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.Flush();
            myXmlTextWriter.Close();
        }

        public bool HaveBeenChecked = false;

        DateTime publishDate = DateTime.Parse("2016-04-16");

        public void CheckUpdate()
        {
            TimeSpan timeDifference = DateTime.Now - publishDate;
            if(timeDifference.Days % 3 != 0)
            {
                this.HaveBeenChecked = true;
                return;
            }         

            if(!System.IO.File.Exists(XMLPath))
            {
                this.CreateConfigXML();
            }

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(XMLPath);
            }
            catch
            {
                this.CreateConfigXML();
                doc.Load(XMLPath);
            }
            XmlNode dateNode = doc.SelectSingleNode("Configuration/AppSettings/LastCheckDate");
            if (dateNode == null)
            {
                this.CreateConfigXML();
                doc.Load(XMLPath);
                dateNode = doc.SelectSingleNode("Configuration/AppSettings/LastCheckDate");
            }

            DateTime lastCheckDate = new DateTime();
            lastCheckDate = DateTime.Parse(dateNode.InnerText);

            if (lastCheckDate != DateTime.Now.Date)
            {
                if(this.CheckAvailableUpdate())
                {
                    this.HaveBeenChecked = true;
                    dateNode.InnerText = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    doc.Save(XMLPath);
                }              
            }            
        }

        private bool CheckAvailableUpdate()
        {
            bool checkUpdateSuccess = false;
            HttpLink.ReturnPara rp = HttpLink.Get(UpdateUrl, false);

            if(rp.accessSuccess)
            {
                checkUpdateSuccess = true;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(rp.text);
                XmlNode dateNode = doc.SelectSingleNode("UpdateInformation/Version");
                if (dateNode == null)
                    return false;
                if (dateNode.InnerText != "1.0.0421")
                {
                    string tempStr = "有可用更新:E信自由版" + dateNode.InnerText;
                    dateNode = doc.SelectSingleNode("UpdateInformation/UpdateDescription");
                    if(dateNode == null)
                        return false;

                    tempStr += "\r\n更新内容:\r\n" + dateNode.InnerText;
                    tempStr += "\r\n\r\n是否更新？";
                    System.Windows.Forms.DialogResult result = 
                        MessageShow.Display(tempStr, "更新提示", System.Windows.Forms.MessageBoxButtons.YesNo);
                    if(result == System.Windows.Forms.DialogResult.Yes)
                    {
                        dateNode = doc.SelectSingleNode("UpdateInformation/UpdateLink");
                        if (dateNode == null)
                        {
                            MessageShow.Display("无法获取更新！", "错误");
                            return false;
                        }
                        System.Diagnostics.Process.Start(dateNode.InnerText);
                    }                                     
                }
            }
            return checkUpdateSuccess;
        }
    }
}
