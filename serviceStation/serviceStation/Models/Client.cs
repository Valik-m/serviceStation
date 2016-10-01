using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serviceStation.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}