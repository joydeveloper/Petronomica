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

namespace Petronomica.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new Models.ConstOrder());
        }
        [HttpGet]
        public PartialViewResult GetServiceType(int id)
        {
        
            string[] constructorsarr = new string[] { "_DiplomworkType", "_СourseworkType", "_MagisterworkType"};
         
         
            return  PartialView(constructorsarr[id]);
        }

        [Route("Save")]
        [HttpPost]
        public IActionResult Save(int id,Models.ConstOrder corder, IFormFile[] files, [FromServices]MessageService ms)
        {
        
     
            try
            {
                corder.YFiles = new List<string>(); foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    corder.YFiles.Add(doc.FileName);
                    stream.Close();
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("<h3>Предзаказ №</h3>" + corder.Id);
                sb.Append("<h3>Адрес электронной почты</h3>" + corder.Email);
                sb.Append("<h3>Тема курсовой/ дипломной работы</h3>" + corder.Theme);
                sb.Append("<h3>Содержание/ план работы</h3>" + corder.Plan);
                sb.Append("<h3>Реферат</h3>" + corder.Referat);
                sb.Append("<h3>Введение</h3>" + corder.Intro);
                sb.Append("<h3>Теоретическая часть работы</h3>" + corder.Theory);
                sb.Append("<h3>Аналитическая часть работы</h3>" + corder.Anal);
                sb.Append("<h3>Проблемы и совершенствование предмета исследования</h3>" + corder.Problems);
                sb.Append("<h3>Заключение</h3>" + corder.Conclusion);
                sb.Append("<h3>Список используемой литературы</h3>" + corder.Literature);
                sb.Append("<h3>Презентация</h3>" + corder.Presentation);
                sb.Append("<h3>Доклад к презентации</h3>" + corder.PresentationReport);
                sb.Append("<h3>Желаемая оценка</h3>" + corder.WishMark);
                string[] attachments = new string[corder.YFiles.Count];
                int i = 0;
                foreach (string s in corder.YFiles)
                {
                    attachments[i] = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", s);
                    i++;
                }
                TestConstOrderEmail tcoe = new TestConstOrderEmail(sb.ToString(), attachments);
                TempData["ResultMessage"] = ms.Send(tcoe).ToString();
                TempData["YourMail"] = corder.Email;
                //  return View("Success");
             
                return Content(CreatePreOrder(1).GetType().ToString());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
        private PreOrder CreatePreOrder(int id)
        {
            switch(id)
            {
                case 0:return new DiplomPreOrder();
                case 1: return new CourseWorkPreOrder();
                case 2: return new MagisterPreOrder();
            }
            return null;
        }
    }
}