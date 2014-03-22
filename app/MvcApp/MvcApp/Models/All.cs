using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    
    public class Trip
    {

        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        
        public int TripId { get; set; }
        public string name { get; set; }  // i.e sahara adventure
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int minimunNumberOfGuests { get; set; } // min amount required to be valid
        public int currentNumberofGuests { get; set; }

        public virtual List<Leg> Leg { get; set; }
        
        //public List<Guest> totalAssociatedGuests { get; set; }
    }

    public class Leg//: Trip
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    
        public int LegId { get; set; }
        public int tripId { get; set; }
        public string legName { get; set; }
        public string startLocation { get; set; } // city name 
        public string endLocation { get; set; }   // city name 
        public DateTime LegtartDate { get; set; }
        public DateTime legEndDate { get; set; }

        public virtual List<Guest> LegAssociatedGuests{ get; set; }
    }

    public class Guest
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GuestId { get; set; }
        public string Name { get; set; }
        public virtual List<Leg> listOfLeg { get; set; }
    }
}