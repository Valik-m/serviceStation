using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace serviceStation.Models
{
    using Price = System.Double;
    public class Order
    {
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public Price Amount { get; set; }
        public OrderStatus Status { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
    public enum OrderStatus
    {
        Completed,
        InProgress,
        Cancelled
    } 
}