using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    string content;
                   // Console.WriteLine("Enter Method: ");
                    string Method = "POST";
                    //Console.WriteLine("Enter Uri: ");
                    string uri = "http://localhost:50337/Service1.svc/Ksiazka/json/1";

                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = Method.ToUpper();
                    //if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
                    //{
                    //    Console.WriteLine("Enter FilePath:");
                    //    string FilePath = Console.ReadLine();
                    //    //content = "1";
                    //    //byte[] buffer = Encoding.ASCII.GetBytes(content);
                    //   // req.ContentLength = buffer.Length;
                    //   // req.ContentType = "application/json";
                    //    req.Method = "GET";
                    //    //Stream PostData = req.GetRequestStream();
                    //    //PostData.Write(buffer, 0, buffer.Length);
                    //    //PostData.Close();
                    //}
                    req.Method = "GET";
                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
                    string response = loResponseStream.ReadToEnd();
                    loResponseStream.Close();
                    resp.Close();
                    Console.WriteLine(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to continue?");
            } while (Console.ReadLine().ToUpper() == "Y");
        }
    }
}
