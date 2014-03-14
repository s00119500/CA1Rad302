using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using MvcApp.DAL;
namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceTripRepository _IR;

        public HomeController(InterfaceTripRepository ir) //need to make iterface public
        {
            _IR = ir;
        }

        public ActionResult Index()
        {
            return View(_IR.DisplayAllTrip());
            //throw new Exception(ConfigurationManager.ConnectionStrings["TravelDatabase"].ConnectionString);

        }

        

    }
}
