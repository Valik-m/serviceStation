using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serviceStation.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage ="You don't enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You don't enter last name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You don't enter birthday")]
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [UIHint("Email")]
        public string Email { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}