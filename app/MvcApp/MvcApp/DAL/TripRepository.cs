using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcApp.DAL;

namespace MvcApp.DAL
{
    public class TripRepository:InterfaceTripRepository
    {
        private ContextClass _ctxClass;
        public TripRepository()
        {
            _ctxClass = new ContextClass();
        }

        public IQueryable<Trip> DisplayAllTrip()
        {

            return _ctxClass.Trips;
        }

        public Trip addTrip(Trip t) {
            //_ctxClass.Trips.Add(t);
            _ctxClass.Entry(t).State = EntityState.Added;
            _ctxClass.SaveChanges();
            return t;
        }

        public Leg addLeg(Leg l, Trip t) { return l; }
        //public IQueryable<College2.Models.Student> GetAllStudents()
        //{
        //    return _ctx.Students.Include(s => s.Enrollments).OrderBy(s => s.LastName);
        //}
        //public int saveChanges() { return 1; }
        //public Trip trashTrip(Trip t) { return t; }
    }
}