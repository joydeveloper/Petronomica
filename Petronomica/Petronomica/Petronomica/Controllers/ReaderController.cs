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
        private readonly IBlogRepo _blogrepo;
        public ReaderController(IBlogRepo blogcontrol)
        {
            _blogrepo = blogcontrol;
            // Only get files that begin with the letter "c."
        }
        public IActionResult Index(int id)
        {
            _blogrepo.GetArticlesAsync().Result.SetActive(id);
            return View(_blogrepo.GetArticlesAsync().Result);
        }
    }
  
}