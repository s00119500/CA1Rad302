using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        //public IQueryable<College2.Models.Student> GetAllStudents()
        //{
        //    return _ctx.Students.Include(s => s.Enrollments).OrderBy(s => s.LastName);
        //}
    }
}