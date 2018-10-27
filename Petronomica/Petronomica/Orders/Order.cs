using System;

namespace Orders
{
    public class Order
    {
        private static int id;
        public Order(string Ordertype)
        {
            id++;
            Id = id;
            OrderDate = DateTime.Now;
            OrderType = Ordertype;
            OrderStatus = "Предзаказ";
        }
        public Order()
        {
           
        }
        public int Id { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
   // public enum Status { Preorder, InWork, Complete, ReWork }
}
