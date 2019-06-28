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
            PTTDATA PTTconn = new PTTDATA();
            List<PTTDATAtype> cards = PTTconn.GetPTTDATA();
            ViewBag.cards = cards;
            return View();
        }

       
    }
}