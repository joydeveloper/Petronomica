﻿using System;
using System.Collections.Generic;
using System.IO;
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

    //TODO  transfer scripts from view to file
    //TODO resize productconfig images
    //TODO main button collapsel
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
            _serviceviewsarr = new string[] { "_Consul", "_Course", "_Diploma", "_Magister", "_ComplexAnalyze", "_Report", "_CreditBP", "_InvestBP", "_SearchPaid" };
            _detailsimages = new string[] { "/images/products/512/consul.png", "/images/products/512/course.png", "/images/products/512/diplom.png", "/images/products/512/magister.png", "/images/products/512/analyze.png", "/images/products/512/practice.png", "/images/products/512/businesscredit.png", "/images/products/512/businessinvest.png", "/images/products/512/search.png" };
            _mobileimages = new string[] { "/images/products/128/consul.png", "/images/products/128/course.png", "/images/products/128/diplom.png", "/images/products/128/magister.png", "/images/products/128/analyze.png", "/images/products/128/practice.png", "/images/products/128/businesscredit.png", "/images/products/128/businessinvest.png", "/images/products/512/search.png" };
            _description = new string[] { "/pages/Consul.html", "/pages/Course.html", "/pages/Diploma.html", "/pages/Magister.html", "/pages/ComplexAnalyze.html", "/pages/Report.html", "/pages/BP.html", "/pages/InvestBP.html", "/pages/SearchPaid.html" };
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
            return PartialView(_serviceviewsarr[id - 1]);
        }
        public IActionResult GetOrderInfo()
        {
            return PartialView("_GetOrderInfo");
        }
        private OrderViewModel OrderRoutine(int id)//,EmailType et)
        {
            Order temporder = _orderrepo.CreatePreOrder(id);
            _orderrepo.SetPreorder(temporder);
            _lastorderid = temporder.Id;
            OrderViewModel ovm = new OrderViewModel(temporder);
            return ovm;
        }
        [HttpPost]
        public async Task<IActionResult> SaveConsul(ConsulDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(1);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            ConsulPreOrderEmail preOrderEmail = new ConsulPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            ConsulPreOrderEmail preOrderEmailr = new ConsulPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            preOrderEmailr.To = "mainpetronomist@petronomica.ru";
            await _ms.Send(preOrderEmail);
            await _ms.Send(preOrderEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCourse(CourseDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(2);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            CoursePreOrderEmail preOrderEmail = new CoursePreOrderEmail(_lastorderid, detail, orderViewModel, files);
            CoursePreOrderEmail preOrderEmailr = new CoursePreOrderEmail(_lastorderid, detail, orderViewModel, files);
            preOrderEmailr.To= "mainpetronomist@petronomica.ru";
            preOrderEmailr.Subject = detail.Email;
           await _ms.Send(preOrderEmail);
            await _ms.Send(preOrderEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveDiploma(DiplomaDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(3);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            DiplomaPreOrderEmail courseEmail = new DiplomaPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            DiplomaPreOrderEmail courseEmailr = new DiplomaPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMagister(DiplomaDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(4);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            MagisterPreOrderEmail courseEmail = new MagisterPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            MagisterPreOrderEmail courseEmailr = new MagisterPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveReport(PracticeReportDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(6);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            PracticeReportPreOrderEmail courseEmail = new PracticeReportPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            PracticeReportPreOrderEmail courseEmailr = new PracticeReportPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveSearchPaid(SearchPaidDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(9);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            SearchPreOrderEmail courseEmail = new SearchPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            SearchPreOrderEmail courseEmailr = new SearchPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveComplexAnalyze(AFDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(5);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            AFPreOrderEmail courseEmail = new AFPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            AFPreOrderEmail courseEmailr = new AFPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCreditBP(CreditBPDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(7);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            CreditBPPreOrderEmail courseEmail = new CreditBPPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            CreditBPPreOrderEmail courseEmailr = new CreditBPPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
            return View("OrderSettings", orderViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SaveInvestBP(InvestBPDetail detail, IFormFile[] files)
        {
            TempData["YourMail"] = detail.Email;
            TempData["YourMessage"] = detail.Message;
            OrderViewModel orderViewModel = OrderRoutine(8);
            int z = 0;
            detail.YFiles = new string[files.Length];
            foreach (IFormFile doc in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await doc.CopyToAsync(stream);
                detail.YFiles[z] = path;
                stream.Close();
                z++;
            }
            InvestBPPreOrderEmail courseEmail = new InvestBPPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            InvestBPPreOrderEmail courseEmailr = new InvestBPPreOrderEmail(_lastorderid, detail, orderViewModel, files);
            courseEmailr.To = "mainpetronomist@petronomica.ru";
            courseEmailr.Subject = detail.Email;
            await _ms.Send(courseEmail);
            await _ms.Send(courseEmailr);
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