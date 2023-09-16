using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.CompilerServices;
using System.Net.Http;

namespace HttpClient_App
{
    class Program
    {
        public static string fileOutput = @"C:\Users\Connor\source\repos\HttpClient_App\HttpClient_App\Output.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Enter URL");
            string url = Console.ReadLine();
            var awaiter = callURL(url);
            if (awaiter.Result != "")
            {
                File.WriteAllText(fileOutput, awaiter.Result);
                Console.WriteLine("HTML response output to " + fileOutput);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        public static async Task<string> callURL(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(url);
            return await response;
        }
    }
}
