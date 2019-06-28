using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTTDATALOAD.mvc.Controllers
{
    public class PTTDATAController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int id = 18)
        {
            return HttpUtility.HtmlEncode("你好" + name + ", ID: " + id);
        }
    }
}