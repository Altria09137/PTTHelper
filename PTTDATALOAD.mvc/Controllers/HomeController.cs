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

   
        
        public ActionResult PTTcontext(int id)
        {
            PTTcontext dBmanager = new PTTcontext();
            List<PTTDATAtype> cards = dBmanager.PTTcontextSearch(id);
            ViewBag.cards = cards;
            return View();
        }


        [HttpPost]
        public ActionResult Search(string pop,int page = 1)
        {
            Search dBmanager = new Search();
            List<PTTDATAtype> cards = dBmanager.GetPTTDATApop(pop);
            ViewBag.MyPageList = cards.ToPagedList(page, 25);

            return View();
        }

     

        public ActionResult SearchDATAget()
        {


            return View();
        }

        [HttpPost]
        public ActionResult TitleSearch(string title, int page = 1)
        {
            Titlesearch dBmanager = new Titlesearch();
            List<PTTDATAtype> cards = dBmanager.GetPTTDATAtitle(title);
            ViewBag.MyPageList = cards.ToPagedList(page, 25);

            return View();
        }

        public ActionResult SearchDATAtitle()
        {


            return View();
        }










    }
}