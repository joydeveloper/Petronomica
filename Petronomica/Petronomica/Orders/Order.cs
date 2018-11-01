using System;

namespace Orders
{
    public class Order
    {
        public const string zeroorder = "Предзаказ";
        private static int id;
        public Order(string Ordertype)
        {
            id++;
            Id = id;
            OrderDate = DateTime.Today;
            OrderType = Ordertype;
            OrderStatus = zeroorder;
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
