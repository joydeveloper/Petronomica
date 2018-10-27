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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePreOrder(int id)
        {
           // Order preorder=new Order()
            return Content(id.ToString()+"FKFKKF");

        }
    }
}