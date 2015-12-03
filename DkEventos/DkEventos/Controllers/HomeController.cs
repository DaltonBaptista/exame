using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DkEventos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult basic_form()
        {

            return View();
        }

        public ActionResult general() {


            return View();
        }

        public ActionResult simple() {

            return View();
        }


    }
}