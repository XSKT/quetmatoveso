using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GeneralKey
{
    class HandelXml
    {
        public void writeXML(string key,string tenfile)
        { 
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(@"<?xml version='1.0' encoding='utf-8' ?>
                                <config>
                                    <key>" + key + @"</key>
                                </config>");
            xmldoc.Save(tenfile);
   
        } 

        public string RandomString( bool lowerCase)
        {
            
            StringBuilder sb = new StringBuilder();
            char c;
            
            Random rand = new Random();
            for (int i = 0; i < 12; i++)
            {
                if (i == 4 || i ==8)
                    sb.Append("-");
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
                return sb.ToString().ToLower();
            return sb.ToString();

        }
    }
}
