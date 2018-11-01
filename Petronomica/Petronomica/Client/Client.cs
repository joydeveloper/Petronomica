using System;
using Orders;
namespace Client
{
    public class ClientOrder
    {
        private Order _clientorder;

        public ClientOrder(Order order)
        {
            _clientorder = order;
        }
        public ClientOrder()
        {

        }
        public Order SetOrder(Order order)
        {
            _clientorder = order;
            return _clientorder;
        }
    }
}
