using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //[WebGet(UriTemplate ="/Ksiazka")]
        //List<Ksiazka> getAll();

        //[OperationContract]
        //[WebGet(UriTemplate = "/Ksiazka/{id}",
        //    ResponseFormat =WebMessageFormat.Xml)]
        //Ksiazka getById(string id);

        //[OperationContract]
        //[WebInvoke(UriTemplate = "/Ksiazka/{id}",
        //    Method ="PUT",
        //    RequestFormat = WebMessageFormat.Xml)]
        //string update(Ksiazka element, string id);




        [OperationContract]
        [WebGet(UriTemplate = "/Ksiazka/json",
            ResponseFormat = WebMessageFormat.Xml)]
        string getJsonAll();

        [OperationContract]
        [WebGet(UriTemplate = "/Ksiazka/json/{id}",
            ResponseFormat = WebMessageFormat.Xml)]
        string getJsonById(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Ksiazka/json",
            Method = "POST",
            RequestFormat = WebMessageFormat.Xml)]
        string jsonAdd(string content);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Ksiazka/json/{id}",
        Method = "DELETE",
        RequestFormat = WebMessageFormat.Xml)]
        string jsonDelete(string id);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Ksiazka
    {
        int id = -1;
        string tytul = "";
        float cena = 0;

        public Ksiazka(int id, string tytul, float cena)
        {
            this.id = id;
            this.tytul = tytul;
            this.cena = cena;
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }


        [DataMember]
        public float Cena
        {
            get { return cena; }
            set { cena = value; }
        }
    }
}
