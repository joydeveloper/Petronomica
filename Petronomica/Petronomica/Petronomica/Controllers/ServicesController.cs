using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orders;
namespace Petronomica.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IOrderController _orderController;
        public ServicesController(IOrderController orderController)
        {
            _orderController = orderController;
          //  _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _orderController.GetProducts());
          
        }
        public async Task<IActionResult> CreatePanel()
        {
            return View(await _orderController.GetProducts());

        }
        [HttpPost]
        public IActionResult CreatePreOrder(int id)
        {
            // Order preorder=new Order()
            string res = $@"<button type='button' class='btn btn-primary btn-lg' bs-toggle-modal='simpleModal'>hh</button>";
            string result = _orderController.GetProduct(id).Name;
            return Content(result);

        }
    }
}