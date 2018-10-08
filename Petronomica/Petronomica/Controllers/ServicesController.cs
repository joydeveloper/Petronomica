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
            return View();
        }
        [HttpGet]
        public PartialViewResult GetServiceType(int id)
        {
        
            string[] constructorsarr = new string[] { "_DiplomworkType", "_СourseworkType", "_PracticeworkType"};
         
         
            return  PartialView(constructorsarr[id]);
        }

        [Route("Save")]
        [HttpPost]
        public IActionResult Save(Models.ConstOrder corder, IFormFile[] docs, [FromServices]MessageService ms)
        {
            if (docs == null || docs.Length == 0)
            {
                return Content("File(s) not selected");
            }
            else
            {
                try
                {
                    corder.YFiles = new List<string>(); foreach (IFormFile doc in docs)
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
                    TestConstOrderEmail tcoe = new TestConstOrderEmail(sb.ToString(), Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", corder.YFiles[0]));
                    TempData["ResultMessage"] = ms.Send(tcoe);
                    return View("Success");
                }
                catch (Exception e)
                {
                    return Content(e.ToString());
                }
            }
        }
    }
}