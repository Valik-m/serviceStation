using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace serviceStation.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [RangeYearToCurrent(1768, ErrorMessage = "Invalid year is provided")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Vin is required")]
        public string Vin { get; set; }

        public virtual List<Order> Orders { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}