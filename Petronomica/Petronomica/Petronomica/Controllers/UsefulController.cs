using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using Microsoft.AspNetCore.Mvc;

namespace Petronomica.Controllers
{
    public class UsefulController : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }
    }
}