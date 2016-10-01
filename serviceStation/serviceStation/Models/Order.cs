using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serviceStation.Models
{
    using Price = System.Int32;
    public class Order
    {
        public int OrderId { get; set; }
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