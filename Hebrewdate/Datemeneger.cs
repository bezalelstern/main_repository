using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hebrewdate
{
    internal class Datemeneger
    {
        private XmlDocument _document;

        public Datemeneger(XmlDocument document)
        {
            _document = document;
        }

        public void AddQuery(string[] elemnts, string[] values)
        {
            XmlElement newquery = _document.CreateElement("query");
            for (int i = 0; i < elemnts.Length; i++)
            {
                XmlElement element = _document.CreateElement(elemnts[i]);
                element.InnerText = values[i];
                newquery.AppendChild(element);
            }
            _document.DocumentElement.AppendChild(newquery);

        }

        public void Save()
        {
            Mainproject.save(_document);
        }

        public string getday(string day)
        {
            string[] days = new string[]
            {
            "יום אחד", "שני ימים", "שלשה ימים", "ארבעה ימים", "חמישה ימים", " שישה ימים",
            "תשעה ימים", "עשרה ימים", "אחד עשר יום","שנים עשר יום", "שלושה עשר יום","ארבעה עשר יום"
            ,"חמשה עשר יום", "שישה עשר יום","שבעה עשר יום","שמנה עשר יום","תשעה עשר יום","עשרים יום","אחד ועשרים יום"," שנים ועשרים יום"," שלשה ועשרים יום","ארבעה ועשרים יום", "חמישה ועשרים יום", "שישה ועשרים יום", "שבעה ועשרים יום", "שמנה ועשרים יום", "תשעה ועשרים יום", "יום שלושים"

            };
            int[] daysnum = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            for (int i = 0; i < daysnum.Length; i++)
            {
                if (daysnum[i] == int.Parse(day))
                {
                    return days[i];
                }

            }
            return null;
        }

        public string getdayweek(string day)
        {
            if (day == "ראשון")
            {
                return "אחד";
            }
            else return day;
        }

        public string getdaymonth(string monte)
        {
            if (monte == "תשפד"){ return "ושמונים וארבע"; }
            if (monte == "תשפה") { return "ושמונים וחמש"; }
            if(monte == "תשפו") { return "ושמונים ושש"; }
            if (monte == "תשפז") { return "ושמונים ושבע"; }
            if (monte == "תשפח") { return "ושמונים ושמונה"; }
            if (monte == "תשפט") { return "ושמונים ותשע"; }
            if (monte == "תשצ") { return "ותשעים"; }
            if (monte == "תשצא") { return "ותשעים ואחד"; }
            if (monte == "תשצב") { return "ותשעים ושניים"; }
            if (monte == "תשצג") { return "ותשעים ושלשה"; }
            return null ;
        }
    }
}
