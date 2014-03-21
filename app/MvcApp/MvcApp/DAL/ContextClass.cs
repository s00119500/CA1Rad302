using System;
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

        // changes the db table names from pural to singular
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }// end db Class

    public class TravelInitializer : DropCreateDatabaseIfModelChanges<ContextClass>
    /// this will drop the create database() if the model changes
    {
        //seed moved to migration config.cs
        
    }
}