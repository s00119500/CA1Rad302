﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApp.Models;
using MvcApp.DAL;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace MvcApp.DAL
{
    public class ContextClass : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guest { get; set; }

        //set connection string
        public ContextClass()
            : base("DBC2")
        {
            Database.SetInitializer(new TravelInitializer());
        }

        // changes th db table names from pural to singular
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }// end db Class

    public class TravelInitializer : DropCreateDatabaseIfModelChanges<ContextClass>
    /// this will drop the create database() if the model changes
    {
        protected override void Seed(ContextClass context) // protected /  Seed not seed...
        {
            /// seed data into database
            var seededTrip = new List<Trip> 
            {
            new Trip { name="Tunisan Adventure", minimunNumberOfGuests=50, startDate= DateTime.Parse("1/12/2015"), endDate=DateTime.Parse("29/12/2015") },
            new Trip { name="An Irish Road", minimunNumberOfGuests=50, startDate= DateTime.Parse("1/12/2015"), endDate=DateTime.Parse("29/12/2015") },
            new Trip { name="Why go to France?", minimunNumberOfGuests=50, startDate= DateTime.Parse("1/12/2015"), endDate=DateTime.Parse("29/12/2015") }
            };// end list

            seededTrip.ForEach(t => context.Trips.Add(t));/// adds seeded Trip to the db
            context.SaveChanges();                        ///saves changes

            var seededLeg = new List<Leg> {
                new Leg{ legName="Tunisan Road", tripId=1, LegtartDate=DateTime.Parse("1/12/2015"),legEndDate=DateTime.Parse("7/12/2015"),
                        startLocation="Gabes",endLocation="Gadamis"},
                new Leg{ legName="Gadamis Straight", tripId=1, LegtartDate=DateTime.Parse("8/12/2015"),legEndDate=DateTime.Parse("10/12/2015"),
                        startLocation="Gadamis",endLocation="Tassilì National Park"},
                new Leg{ legName="Home Run", tripId=1, LegtartDate=DateTime.Parse("12/12/2015"),legEndDate=DateTime.Parse("13/12/2015"),
                        startLocation="Tassilì National Park",endLocation="Gabis"},

                new Leg{ legName="Dublin Away", tripId=2, LegtartDate=DateTime.Parse("8/12/2015"),legEndDate=DateTime.Parse("10/12/2015"),
                        startLocation="Dublin",endLocation="Offally"},
                new Leg{ legName="Out of Offally", tripId=2, LegtartDate=DateTime.Parse("10/12/2015"),legEndDate=DateTime.Parse("12/12/2015"),
                        startLocation="Offally",endLocation="Connemara"},
                new Leg{ legName="Connemaran Potholes", tripId=2, LegtartDate=DateTime.Parse("1/12/2015"),legEndDate=DateTime.Parse("7/12/2015"),
                        startLocation="Connemara",endLocation="Connemara"},// lot o potholes
                new Leg{ legName="Home Run", tripId=2, LegtartDate=DateTime.Parse("1/12/2015"),legEndDate=DateTime.Parse("7/12/2015"),
                        startLocation="Connemara",endLocation="Dublin"}

            };// end seededLeg

            //add Leg to db 
            seededLeg.ForEach(l => context.Legs.Add(l));
            context.SaveChanges();
        }
    }
}