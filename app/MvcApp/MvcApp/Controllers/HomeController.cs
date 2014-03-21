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

        //delete a trip or add a leg
        public ActionResult Submit(string option) { return View("Index"); }

        [HttpPost]
        public ActionResult Submit(string option,int id)
        {
            if (option == "Trash") // User clicked "Delete"
            {
                
            }
            else
            {
                // User clicked "Add Trip"
            }
            return View();
    }



        public ActionResult createTrip()
        {
            return View("createTrip");
        }

        [HttpPost]
        public ActionResult createTrip([Bind(Include = "TripId,name,startDate,endDate,minimunNumberOfGuests,Leg")]Trip trip)
        {
            if (ModelState.IsValid)
            {
                _IR.addTrip(trip);
                return View("Index");   
            }
            return View("createTrip");
            
        }

        public ActionResult addLeg() 
        {
            return View (); 
        }

        [HttpPost]
        public ActionResult addLeg([Bind(Include = "")]Leg leg,Trip trip)
        {
            return View();
        }

        
    }
}
