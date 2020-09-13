using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    class Program
    {
        static void LoadCD()
        {
            String url = "https://www.w3schools.com/xml/cd_catalog.xml";
            WebClient webClient = new WebClient();
            String content = webClient.DownloadString(url);

            XmlDocument document = new XmlDocument();
            document.LoadXml(content);

            XmlElement catalog = document["CATALOG"];
            Console.WriteLine("Liczba elementów w CATALOG = " + catalog.ChildNodes.Count);
            foreach (XmlElement cd in catalog.ChildNodes)
            {
                //Console.WriteLine(cd.ToString());
                String title = cd.GetElementsByTagName("TITLE")[0].InnerText;
                String artist = cd.GetElementsByTagName("ARTIST")[0].InnerText;
                String country = cd.GetElementsByTagName("COUNTRY")[0].InnerText;
                String year = cd.GetElementsByTagName("YEAR")[0].InnerText;
                Console.WriteLine($"{title}\t{artist}\t{country}\t{year}");
            }

        }

        static void Main(string[] args)
        {

            LoadCD();

            String filename = @"c:\tmp\persons.xml";
            String content = File.ReadAllText(filename);

            XmlDocument document = new XmlDocument();
            document.LoadXml(content);

            XmlElement persons = document["persons"];
            Console.WriteLine("Liczba elementów w persons =" + persons.ChildNodes.Count);
            foreach (XmlElement item in persons.ChildNodes)
            {
                String name = item.GetAttribute("name");
                String lname = item.GetAttribute("lname");
                String phone = item.GetAttribute("phone");
                Console.WriteLine($"{name}\t{lname}\t{phone}");
            }

        }
    }
}
