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
        HardCodeBlog hcb;
        public ReaderController()
        {
            try
            {
                string[] dirs = Directory.GetFiles("wwwroot/articles/", "*.html");
                hcb = new HardCodeBlog(dirs);
            }
            catch (Exception e)
            {
                hcb = new HardCodeBlog(new string[] { "wwwroot/articles/0312" });
            }
            // Only get files that begin with the letter "c."
        }
        public IActionResult Index(int id)
        {
            hcb.blogItemContainer.SetActive(id);
            return View(hcb);
        }

    }
  
}