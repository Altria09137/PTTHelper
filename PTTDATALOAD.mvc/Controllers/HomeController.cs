using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTTDATALOAD.mvc.Models;



namespace PTTDATALOAD.mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<PTTDATAtype> cards = dBmanager.GetPTTDATA();
            ViewBag.cards = cards;
            return View();
        }

        public ActionResult Search(string pop)
        {
            Search dBmanager = new Search();
            PTTDATAtype card = dBmanager.GetPTTDATApop(pop);
            return View(card);
        }

        [HttpPost]
        public ActionResult Search()
        {


            return RedirectToAction("Index");
        }








    }
}