using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using serviceStation.Models;


namespace serviceStation.DAL
{
    public class ServiceStationContext: DbContext
    {

        public ServiceStationContext() : base ("ServiceStationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ServiceStationContext>());
        }    

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}