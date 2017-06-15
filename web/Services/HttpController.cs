using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using web.Classes;

namespace web.Services
{
    public class HttpController
    {
        public string sendGet(string uri)
        {
            string wynik = "";
            try
            { 
                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = "GET";
             
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                wynik = read(resp);
                resp.Close();
                List<Ksiazka> ksiazka = JsonConvert.DeserializeObject<List<Ksiazka>>(wynik);
                wynik = new JsonTransformService().SerializeToString<List<Ksiazka>>(ksiazka);
            }
            catch (Exception ex)
            {
                wynik = "error";
            }
            return wynik;
        }

        public string sendDelete(string uri)
        {
            string wynik = "";
            try
            {
                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = "DELETE";

                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                wynik = read(resp);
                resp.Close();

            }
            catch (Exception ex)
            {
                wynik = "error";
            }
            Odpowiedz odp = new Odpowiedz();
            odp.odpowiedz = wynik;
            wynik = new JsonTransformService().SerializeToString<Odpowiedz>(odp);
            return wynik;
        }


        public string sendPost(string uri, string content)
        {
            string wynik = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri);

                var data = Encoding.ASCII.GetBytes(content);

                //request.Method = "POST";
                //request.ContentType = "application/json; charset=UTF-8";
                //request.ContentLength = data.Length;

                //using (var stream = request.GetRequestStream())
                //{
                //    stream.Write(data, 0, data.Length);
                //}
                 uri += "?content=" + content;
                var response = (HttpWebResponse)request.GetResponse();
                wynik = read(response);
                response.Close();
              //  var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            }
            catch (Exception ex)
            {
                wynik = "error";
            }
            Odpowiedz odp = new Odpowiedz();
            odp.odpowiedz = wynik;
            wynik = new JsonTransformService().SerializeToString<Odpowiedz>(odp);
            return wynik;
        }

        public string read(HttpWebResponse resp)
        {
            Encoding enc = System.Text.Encoding.GetEncoding(1252); 
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
            string response = loResponseStream.ReadToEnd();
            loResponseStream.Close();
            //int s = response.ToCharArray().Count() - 9;
            string newS = response.Substring(68);
            newS = newS.Substring(0, newS.Length - 9);
            return newS;
        }
    }
}