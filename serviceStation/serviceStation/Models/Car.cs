using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serviceStation.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Vin { get; set; }
        public virtual List<Order> Orders { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}