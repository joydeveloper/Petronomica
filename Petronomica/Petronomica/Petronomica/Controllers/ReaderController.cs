using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HardCodeData;
using Microsoft.AspNetCore.Mvc;

namespace Petronomica.Controllers
{
    public class ReaderController : Controller
    {
        public IActionResult Index()
        {
            HardCodeBlog hcb;
            try
            {
                // Only get files that begin with the letter "c."
                string[] dirs = Directory.GetFiles("wwwroot/articles/","*.html");
                hcb = new HardCodeBlog(dirs);

            }
            catch (Exception e)
            {
                hcb = new HardCodeBlog(new string[] { "wwwroot/articles/0312" });
            }
            // Only get files that begin with the letter "c."
         
               
            return View(hcb);
        }
    }
}