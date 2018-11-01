using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orders;
using Petronomica.ViewModels;

namespace Petronomica.Controllers
{
    //TODO rename iordercontroller!
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
     
 
        public async Task<IActionResult> GetOrderInfo()
        {
            return  PartialView( "_GetOrderInfo");
        }
        // [HttpPost]
    
        public IActionResult OrderSettings(int id)
        {

            return View(new OrderViewModel(_orderController.CreatePreOrder(id)));

        }
    }
}