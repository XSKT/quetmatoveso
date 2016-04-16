using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeneralKey
{
    class HandelXml
    {
        private System.Windows.Forms.ProgressBar progressBar;   
        public void writeXML(string key,string ngay,string tenfile)
        { 
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(@"<?xml version='1.0' encoding='utf-8' ?>
                                <config>
                                    <key>" + key + @"</key>"+
                                    "<ngaytaokey>" + ngay +"</ngaytaokey>"+
                                "</config>");
            xmldoc.Save(tenfile);
   
        }
        private void UpdateProgress()
        {

            progressBar.Value += 1;

        }
        public delegate void updatebar();
        public string RandomString(System.Windows.Forms.ProgressBar progressBar,double size, bool lowerCase)
        {
            this.progressBar = progressBar;
            StringBuilder sb = new StringBuilder();
            char c;
            
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                if (i !=0 && (i % 4 ==0) )
                    sb.Append("-");
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
                this.progressBar.Invoke(new updatebar(this.UpdateProgress));
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();

        }
    }
}
