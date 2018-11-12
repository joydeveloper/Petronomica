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
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Консультация по НИР", Rating = 5,Path = "'../images/products/consul.png'" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Курсовая", Rating = 5, Path = "'../images/products/course.png'" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Диплом",Rating= 5, Path = "'../images/products/diplom.png'" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Магистерская диссертация", Rating = 5, Path = "'../images/products/magister.png'" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 1, Name = "Комплексный анализ предприятия", Rating = 5, Path = "'../images/products/analyze.png'" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 2, Name = "Отчет по практике", Rating = 5, Path = "'../images/products/practice.png'" });
            pitems.Add(new Portfolio.PortfolioItem { IdEmployee = 2, Name = "Бизнес-план для получения кредита", Rating = 5, Path = "'../images/products/businesscredit.png'" });
        
        }
        public async Task<IEnumerable<Portfolio.PortfolioItem>> GetItems()
        {
            return await Task.Run(() => pitems);
        }
    }
    public class PortfolioController : Controller
    {
       

        public IActionResult Index()
        {

            return View();
        }
    }
}