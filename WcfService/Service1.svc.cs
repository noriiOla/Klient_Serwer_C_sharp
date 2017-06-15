using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using web.Classes;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        // private static List<Ksiazka> lista;

        private static List<Ksiazka> lista;

        public Service1()
        {
            lista = new List<Ksiazka>(){
                new Ksiazka ( 1, "t1", 1),
                 new Ksiazka ( 2, "t2", 1),
                  new Ksiazka ( 3, "t3", 1),
            };
        }

        //public List<Ksiazka> getAll()
        //{
        //    return lista;
        //}

        //public Ksiazka getById(string id)
        //{
        //    return lista.Find(b => b.Id.Equals(id));
        //}



        public string getJsonAll()
        {
            return JsonConvert.SerializeObject(lista);
        }

        public string getJsonById(string id)
        {
            Ksiazka k = lista.Find(b => b.Id == Convert.ToInt32( id));
            List<Ksiazka> listaK = new List<Ksiazka>();
            listaK.Add(k);
            return JsonConvert.SerializeObject(listaK);
           
        }

        public string jsonAdd(string content)
        {
             Ksiazka ks = JsonConvert.DeserializeObject<Ksiazka>(content);

            //Encoding enc = System.Text.Encoding.GetEncoding(1252);
            //StreamReader loResponseStream = new StreamReader(content.GetRequestStream(), enc);
            //string req = loResponseStream.ReadToEnd();


            //string data = request.
            int maxId = 1;

            foreach (Ksiazka ksiazka in lista)
            {
                if (ksiazka.Id > Convert.ToInt32(maxId))
                {
                    maxId = ksiazka.Id;
                }
            }
          //  Ksiazka ks = JsonConvert.DeserializeObject<Ksiazka>(req);
            ks.Id = maxId + 1;
            lista.Add(ks);
            return (maxId + 1).ToString();
        }

        public string jsonDelete(string id)
        {
            Ksiazka k = lista.Find(b => b.Id == Convert.ToInt32(id));
           
            if(k == null)
            {
                return "404";
            }else
            {
                lista.Remove(k);
                return "202";
            }
        }
    }
}
