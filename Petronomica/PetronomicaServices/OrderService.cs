using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HardCodeData;
using Orders;
using Products;

namespace PetronomicaServices
{
    public class OrderService
    {
        IOrderController _ordercontrol;
        public OrderService(IOrderController ordercontrol)
        {
            _ordercontrol = ordercontrol;
        }
        public Order CreatePreOrder(int id)
        {
            return _ordercontrol.CreatePreOrder(id);
        }
        public async Task PromoteOrder(Order order)
        {
            await _ordercontrol.PromoteOrder(order);
        }

    }
}
public interface IOrderController
{
    Order CreatePreOrder(int id);
    Task PromoteOrder(Order order);
    Task<IEnumerable<Product>> GetProducts();
    Product GetProduct(int id);
}
public class HardCodeOrderController : IOrderController
{
    private HardCodeProducts hardCodeProducts = new HardCodeProducts();
    public  Order CreatePreOrder(int id)
    {
        return new Order(hardCodeProducts.products.Find(x => x.Id == id).Name);
    }
    public Product GetProduct(int id)
    {
        return hardCodeProducts.products.Find(x=>x.Id==id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await Task.Run(() => hardCodeProducts.products);
    }

    public Task PromoteOrder(Order order)
    {
        throw new NotImplementedException();
    }

 
}