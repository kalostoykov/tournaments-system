using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YoyoTournaments.WebClient.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return this.View("Error");
        }

        public ActionResult Page400()
        {
            return this.View();
        }

        public ActionResult Page404()
        {
            return this.View();
        }

        public ActionResult Page500()
        {
            return this.View();
        }
    }
}