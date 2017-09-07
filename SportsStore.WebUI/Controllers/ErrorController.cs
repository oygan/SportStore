using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public string Index()
        {
            return "Error, go home page";
        }
    }
}