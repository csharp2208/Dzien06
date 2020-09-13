using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonParser
{
    class Program
    {

        static void ParseNBP()
        {
            String url = "http://api.nbp.pl/api/exchangerates/tables/A/?format=json";
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;
            String json = wb.DownloadString(url);
            int jsonLength = json.Length;
            json = json.Substring(1, jsonLength - 2);

            JObject jsonData = JObject.Parse(json);
            foreach (JToken item in jsonData["rates"])
            {
                String currency = item["currency"].ToString();
                String code = item["code"].ToString();
                double mid = Convert.ToDouble(item["mid"]);

                Console.WriteLine($"{currency}\t{code}\t{mid}");
            }

        }

        static void Main(string[] args)
        {
            ParseNBP();

            String url = "http://dummy.restapiexample.com/api/v1/employees";
            WebClient wb = new WebClient();
            String json = wb.DownloadString(url);

            JObject jsonData = JObject.Parse(json);
            Console.WriteLine("status=" + jsonData["status"]);

            foreach (JToken item in jsonData["data"])
            {
                int _id = Convert.ToInt32(item["id"]);
                String name = item["employee_name"].ToString();
                double salary = Convert.ToDouble(item["employee_salary"]);
                int age = Convert.ToInt32(item["employee_age"]);
                String image = item["profile_image"].ToString();
                Console.WriteLine($"{_id}\t{name}\t{salary}\t{age}");
            } 

            Console.ReadKey();
        }
    }
}
