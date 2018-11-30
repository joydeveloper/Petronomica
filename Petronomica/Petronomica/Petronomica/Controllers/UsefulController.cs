using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog;
using Microsoft.AspNetCore.Mvc;

namespace Petronomica.Controllers
{
    public class UsefulController : Controller
    {

        private readonly IBlogRepo _blogrepo;
        public UsefulController(IBlogRepo blogcontrol)
        {
            _blogrepo = blogcontrol;
            // Only get files that begin with the letter "c."
        }
        public IActionResult Index()
        {
            return View(_blogrepo.GetArticlesAsync().Result);
        }
    }
}