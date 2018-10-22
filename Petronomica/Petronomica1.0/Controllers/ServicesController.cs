using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petronomica.Models;
using Petronomica.Services;
using Petronomica.ViewModels;
//TODO back to tops
namespace Petronomica.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public PartialViewResult GetServiceType(int id)
        {
            string[] constructorsarr = new string[] { "_DiplomworkType", "_СourseworkType", "_MagisterworkType","_SearchPaid" };
            return PartialView(constructorsarr[id]);
        }
        [HttpGet]
        public PartialViewResult GetFastOrder(int id)
        {
            string[] constructorsarr = new string[] { "Диплом", "Курсовая", "Диссертация","Отчет" };
            PreOrderViewModel n = new PreOrderViewModel();
            n.Title = constructorsarr[id];
            return PartialView("_FastOrder",n);//, constructorsarr[id]);
        }
        [HttpPost]
        public IActionResult Consultation()
        {

            return Content("Оформленно");
        }
        [HttpPost]
        public IActionResult FastOrder(PreOrderViewModel povm, IFormFile[] files, [FromServices]MessageService ms)
        {
           
            PreOrder po = new PreOrder();
            po.Email = povm.Email;
            po.YFiles = povm.YFiles;
            po.Message = povm.Message;
            po.Title = povm.Title;
            try
            {
                int z = 0;
                po.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    po.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                FastOrderEmail poe = new FastOrderEmail(po);
                FastOrderEmailReport tcoe = new FastOrderEmailReport(po);
                TempData["ResultEmploer"] = ms.Send(poe).ToString();
                TempData["ResultReport"] = ms.Send(tcoe).ToString();
                return View("Success");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        [Route("Save")]
        [HttpPost]
        public IActionResult Save(Models.DiplomPreOrder corder, IFormFile[] files, [FromServices]MessageService ms)
        {
            try
            {
                int z = 0;
                corder.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    corder.YFiles[z]=path;
                    stream.Close();
                    z++;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("<h3>Предзаказ № " + corder.Id+"</h3>");
                sb.Append("<h3>Адрес электронной почты:" + corder.Email + "</h3>");
                sb.Append("<h3>Тема курсовой/ дипломной работы-" + BoolToRus(corder.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(corder.Plan) + "</h3>");
                sb.Append("<h3>Реферат-" + BoolToRus(corder.Referat) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(corder.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(corder.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(corder.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(corder.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(corder.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(corder.Literature) + "</h3>");
                sb.Append("<h3>Презентация-" + BoolToRus(corder.Presentation) + "</h3>");
                sb.Append("<h3>Доклад к презентации-" + BoolToRus(corder.PresentationReport) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + corder.WishMark + "</h3>");
                corder.Message += sb.ToString();
                PreOrderEmail poe = new PreOrderEmail(corder);
                PreOrderEmailReport tcoe = new PreOrderEmailReport(corder);
                TempData["ResultEmploer"] = ms.Send(poe).ToString();
                TempData["ResultReport"] = ms.Send(tcoe).ToString();
                return View("Success");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        [Route("SaveC")]
        [HttpPost]
        public IActionResult SaveC(Models.CourseWorkPreOrder corder, IFormFile[] files, [FromServices]MessageService ms)
        {
            try
            {
                int z = 0;
                corder.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    corder.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("<h3>Предзаказ № " + corder.Id + "</h3>");
                sb.Append("<h3>Адрес электронной почты:" + corder.Email + "</h3>");
                sb.Append("<h3>Тема курсовой/ дипломной работы-" + BoolToRus(corder.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(corder.Plan) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(corder.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(corder.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(corder.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(corder.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(corder.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(corder.Literature) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + corder.WishMark + "</h3>");
                corder.Message += sb.ToString();
                PreOrderEmail poe = new PreOrderEmail(corder);
                PreOrderEmailReport tcoe = new PreOrderEmailReport(corder);
                TempData["ResultEmploer"] = ms.Send(poe).ToString();
                TempData["ResultReport"] = ms.Send(tcoe).ToString();
                return View("Success");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        private string BoolToRus(bool val)
        {
            if (val)
                return "Да";
            else
                return "Нет";
        }
    }
}
   
