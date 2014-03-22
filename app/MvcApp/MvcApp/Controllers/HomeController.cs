using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using MvcApp.DAL;
using System.Data.Entity;
namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceTripRepository _IR;
        private ContextClass ctx = new ContextClass();

        public HomeController(InterfaceTripRepository ir) //need to make iterface public
        {
            _IR = ir;
        }

        public ActionResult Index()
        {
            return View(_IR.DisplayAllTrip());
            //throw new Exception(ConfigurationManager.ConnectionStrings["TravelDatabase"].ConnectionString);

        }
        //public ActionResult createTrip() 
        //{
        //    return View("createTrip"); 
        //}

        //public ActionResult addTrip()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult addTrip([Bind(Include = "[TripId],[name],[startDate],[endDate],[minimunNumberOfGuests]")] Trip trip)
        //{
        //   if (ModelState.IsValid)
        //    {
        //        _IR.addTrip(trip);
               
        //        return RedirectToAction("Index");
        //    }
        //    // if not valid, re-send View with already entered data
        //    return View("createTrip",trip);
             
        //}
       

        //public ActionResult trashTrip(int id = 0)
        //{
        //    Trip trip = ctx.Trips.Find(id);
        //    if (trip == null)
        //    {
        //        return HttpNotFound();
                
        //    }
        //    //Trip trip = ctx.Trips.Find(id);
        //    ctx.Trips.Remove(trip);
        //    ctx.SaveChanges();
        //    return RedirectToAction("Index");
           
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    ctx.Dispose();
        //    base.Dispose(disposing);
        //}

        //public ActionResult addLeg()
        //{
        //    return View(); 
        //}

        public ActionResult Details(int id = 0)
        {
            Trip trip = ctx.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //
        // GET: /Home/Create

        public ActionResult createTrip()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createTrip(Trip trip)
        {
            if (ModelState.IsValid)
            {
                ctx.Trips.Add(trip);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Trip trip = ctx.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trip trip)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(trip).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Trip trip = ctx.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = ctx.Trips.Find(id);
            ctx.Trips.Remove(trip);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}
#region unused code
/*
 *  //delete a trip or add a leg
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

 */
#endregion