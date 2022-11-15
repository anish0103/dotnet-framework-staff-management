using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public PartialViewResult DashboardView()
        {
            return PartialView("_DashboardView");
        }
    }
}