using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Petronomica.Controllers
{
    public class HardCodePortfolio
    {

        public List<Portfolio.PortfolioItem> pitems;
        public HardCodePortfolio()
        {
            pitems = new List<Portfolio.PortfolioItem>();
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Диссертация", Rating = 5,downloadPath= "../userwfiles/portfolio/Disser.docx" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Курсовая", Rating = 5, downloadPath = "../userwfiles/portfolio/Problems.docx" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Курсовая",Rating= 5, downloadPath = "../userwfiles/portfolio/Unemployment.doc" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Бизнес-план", Rating = 5 , downloadPath = "../userwfiles/portfolio/BP.docx" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Отчет", Rating = 5, downloadPath = "../userwfiles/portfolio/Report.docx" });
           
        
        }
        public async Task<IEnumerable<Portfolio.PortfolioItem>> GetItems()
        {
            return await Task.Run(() => pitems);
        }
    }
    public class PortfolioController : Controller
    {
        private HardCodePortfolio hcd;
        public PortfolioController()
        {
            hcd = new HardCodePortfolio();
        }

        public async Task<IActionResult> Index()
        {

            return View(await hcd.GetItems());
        }
    }
}