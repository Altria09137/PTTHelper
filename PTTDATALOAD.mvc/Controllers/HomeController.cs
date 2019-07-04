using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTTDATALOAD.mvc.Models;
using PagedList;



namespace PTTDATALOAD.mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page=1)
        {

          

            DBmanager dBmanager = new DBmanager();
            List<PTTDATAtype> cards = dBmanager.GetPTTDATA();
            ViewBag.MyPageList = cards.ToPagedList(page, 25);
           
  
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