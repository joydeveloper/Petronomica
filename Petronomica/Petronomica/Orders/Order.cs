using System;

namespace Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public Status OrderStatus { get; set; }
    }
    public enum Status { Preorder, InWork, Complete, ReWork }
}
