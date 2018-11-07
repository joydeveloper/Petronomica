using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders;
using Petronomica.Models;
using Petronomica.ViewModels;
using SharedServices;

namespace Petronomica.Controllers
{
    //TODO rename iordercontroller!
    //TODO  transfer scripts from view to file
    //TODO resize productconfig images
    public class ServicesController : Controller
    {
        private readonly IMessageSender _ms;
        private readonly IOrderRepo _orderrepo;
        public List<ProductExtViewModel> _serviceproducts;
        private int _lastorderid;
        private string[] _serviceviewsarr;
        private string[] _detailsimages;
        private string[] _mobileimages;
        private string[] _description;
        public ServicesController(IOrderRepo orderController, IMessageSender ms)
        {
            _orderrepo = orderController;
            _serviceproducts = new List<ProductExtViewModel>();
            _serviceviewsarr = new string[] { "_Consul", "_Course", "_Diploma", "_Magister","_ComplexAnalyze","_Report","_BP","_InvestBP" };
            _detailsimages= new string[] { "/images/products/512/consul.png", "/images/products/512/course.png", "/images/products/512/diplom.png", "/images/products/512/magister.png", "/images/products/512/analyze.png", "/images/products/512/practice.png", "/images/products/512/businesscredit.png", "/images/products/512/businessinvest.png" };
            _mobileimages = new string[] { "/images/products/128/consul.png", "/images/products/128/course.png", "/images/products/128/diplom.png", "/images/products/128/magister.png", "/images/products/128/analyze.png", "/images/products/128/practice.png", "/images/products/128/businesscredit.png", "/images/products/128/businessinvest.png" };
            _description= new string[] { "/pages/Consul.html", "/pages/Course.html", "/pages/Diploma.html", "/pages/Magister.html", "/pages/ComplexAnalyze.html", "/pages/Report.html", "/pages/BP.html", "/pages/InvestBP.html" };
            _ms = ms;

        }
     
        public async Task<IActionResult> Index()
        {
            return View(await _orderrepo.GetProducts());
          
        }
        public async Task<IActionResult> CreatePanel()
        {
            return View(await _orderrepo.GetProducts());

        }
        [HttpGet]
        public PartialViewResult GetServiceType(int id)
        {
            return PartialView(_serviceviewsarr[id-1]);
        }
        public async Task<IActionResult> GetOrderInfo()
        {
            return  PartialView( "_GetOrderInfo");
        }
        private OrderViewModel OrderRoutine(int id)//,EmailType et)
        {
            Order temporder = _orderrepo.CreatePreOrder(id);
            _orderrepo.SetPreorder(temporder);
            _lastorderid = temporder.Id;
            OrderViewModel ovm = new OrderViewModel(temporder);
            //await _ms.Send(et);
            return ovm;
        }
       
        [HttpPost]
        public async Task<IActionResult> SaveConsul(ConsulDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(1);
            ConsulPreOrderEmail preOrderEmail = new ConsulPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            await _ms.Send(preOrderEmail);
            return View("OrderSettings",orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCourse(CourseDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(2);
            CoursePreOrderEmail preOrderEmail = new CoursePreOrderEmail(_lastorderid, detail, orderViewModel, files);
            await _ms.Send(preOrderEmail);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveDiploma(DiplomaDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(3);
            DiplomaPreOrderEmail courseEmail = new DiplomaPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            await _ms.Send(courseEmail);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMagister(DiplomaDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(4);
           MagisterPreOrderEmail courseEmail = new MagisterPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            await _ms.Send(courseEmail);
            return View("OrderSettings", orderViewModel);
        }
        // [HttpPost]
        public IActionResult ProductConfig(int id)
        {
            ProductExtViewModel previewproduct = new ProductExtViewModel(_orderrepo.GetProduct(id), _serviceviewsarr[id - 1], _description[id - 1], _detailsimages[id - 1], _mobileimages[id - 1], null);
            return View(previewproduct);
        }
        public IActionResult OrderSettings()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult GetUserInfo()
        {
            UserMessageViewModel userMessageViewModel = new UserMessageViewModel();
            return PartialView("_UserInfo", userMessageViewModel);//, constructorsarr[id]);
        }
        [Route("Save")]
        [HttpPost]
        public IActionResult Save(PreOrderViewModel povm)
        {
            return Content(povm.ToString());
        }
    }
}