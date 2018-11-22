using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petronomica.Models;
using SharedServices;

namespace Petronomica.Controllers
{
    public class MiscController : Controller
    {
        private readonly IMessageSender _ms;
        public MiscController( IMessageSender ms)
        {
            _ms = ms;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMiscInfo()
        {
            return  PartialView("_GetMiscInfo");
        }
        public IActionResult Project()
        {
            return View();
        }
              public IActionResult Guarantee()
        {
            return View();
        }
        public IActionResult PaidMethods()
        {
            return View();
        }
        public IActionResult AntiPlagiat()
        {
            return View();
        }
        public IActionResult Wish()
        {
            return View();
        }
        public IActionResult WishSuccess()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WishGet(ConsulDetail detail)
        {

            WishEmail Email = new WishEmail( detail.Email, detail.Message);
            await _ms.Send(Email);
            return View("WishSuccess");
        }
    }
}