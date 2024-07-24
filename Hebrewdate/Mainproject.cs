using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hebrewdate
{
    internal class Mainproject
    {
        private static string pathString = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..") + "\\hebrew_date.xml");


        public static XmlDocument Main()
        {
            //string pathString = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..") + "\\hebrew_date.xml");
            XmlDocument doc;
            if (File.Exists(pathString))
            {
                doc = new XmlDocument();
                doc.Load(pathString);

            }
            else
            {
                doc = new XmlDocument();
                XmlNode Node = doc.CreateElement("queries");
                doc.AppendChild(Node);
                doc.Save(pathString);
                doc.Load(pathString);
            }
            return doc;
        }
        public static void save(XmlDocument xml)
        {
            xml.Save(pathString);
        }
    }
}

