using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApp.Models;
namespace MvcApp.DAL
{
    public interface InterfaceTripRepository
    {
        
        // show all Trip 
        IQueryable<Trip> DisplayAllTrip();
        // add trip 
        Trip addTrip(Trip t);
        //Trip trashTrip(int? id);
        //// add leg, you'll need the trip your adding it to
        Leg addLeg(Leg l, Trip t);
        //int savechanges();
    }
    
}