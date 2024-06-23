using System;
namespace AJAXTest.Models
{
    public class OrderModel
    {
        public static int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderAt { get;} = DateTime.Now.Date;
        public decimal TotalCost { get; set; }
    }
}