using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Classes;
using web.Services;

namespace web.Controllers
{
    public class JsController : Controller
    {
        HttpController httpController;

        public JsController()
        {
            httpController = new HttpController();
        }
        // GET: Js
        public ActionResult Index()
        {
            return View();
        }

        public string showAll()
        {
            string s = this.httpController.sendGet("http://localhost:50337/Service1.svc/Ksiazka/json");
            return s;
        }

        public string getById(string ind)
        {
            string s = this.httpController.sendGet("http://localhost:50337/Service1.svc/Ksiazka/json/" + ind);
            return s; 
        }

        public string deleteById(string ind)
        {
            string s = this.httpController.sendDelete("http://localhost:50337/Service1.svc/Ksiazka/json/" + ind);
            return s;
        }

        public string add(string tytul, string cena)
        {
            Ksiazka ks = new Ksiazka()
            {
                tytul = tytul,
                cena = cena
            };
            string content = new JsonTransformService().SerializeToString<Ksiazka>(ks);
            string s = this.httpController.sendPost("http://localhost:50337/Service1.svc/Ksiazka/json", content);
            return "";
        }
    }
}