using Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardCodeData
{
   public class HardCodeOrders
    {
        public List<Order> _orders;
        public HardCodeOrders()
        {
            _orders = new List<Order>();

        }
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        
    }
}
