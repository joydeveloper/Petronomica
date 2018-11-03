using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client;
using Microsoft.AspNetCore.Mvc;
using Orders;
using Petronomica.ViewModels;

namespace Petronomica.Controllers
{
    //TODO rename iordercontroller!
    public class ServicesController : Controller
    {
        private readonly IOrderRepo _orderrepo;
        public ServicesController(IOrderRepo orderController)
        {
            _orderrepo = orderController;
          //  _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _orderrepo.GetProducts());
          
        }
        public async Task<IActionResult> CreatePanel()
        {
            return View(await _orderrepo.GetProducts());

        }
     
 
        public async Task<IActionResult> GetOrderInfo()
        {
            return  PartialView( "_GetOrderInfo");
        }
        // [HttpPost]
    
        public IActionResult OrderSettings(int id)
        {

            return View(new OrderViewModel(_orderrepo.CreatePreOrder(id)));

        }
        [HttpGet]
        public PartialViewResult GetUserInfo()
        {

            UserMessageViewModel userMessageViewModel = new UserMessageViewModel();
            return PartialView("_UserInfo", userMessageViewModel);//, constructorsarr[id]);
        }
        [Route("Save")]
        [HttpPost]
        public IActionResult Save(UserMessageViewModel umvm)
        {
            return Content(umvm.ToString());
        }
            public IActionResult SetOrder(ClientOrder co)
        {
            

            // _orderrepo.
            //PreOrder po = new PreOrder();
            //po.Email = povm.Email;
            //po.YFiles = povm.YFiles;
            //po.Message = povm.Message;
            //po.Title = povm.Title;
            //try
            //{
            //    int z = 0;
            //    po.YFiles = new string[files.Length];
            //    foreach (IFormFile doc in files)
            //    {
            //        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
            //        var stream = new FileStream(path, FileMode.Create);
            //        doc.CopyToAsync(stream);
            //        po.YFiles[z] = path;
            //        stream.Close();
            //        z++;
            //    }
            //    FastOrderEmail poe = new FastOrderEmail(po);
            //    FastOrderEmailReport tcoe = new FastOrderEmailReport(po);
            //    TempData["ResultEmploer"] = ms.Send(poe).ToString();
            //    TempData["ResultReport"] = ms.Send(tcoe).ToString();
            //    return View("Success");
            //}
            //catch (Exception e)
            //{
            //    return Content(e.ToString());
            //}
           // _orderrepo.SetPreorder(_order);
            return View("SuccessOrder");
        }
    }
}