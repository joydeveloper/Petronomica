using Products;
using System;
using System.Collections.Generic;

namespace HardCodeData
{
    public class HardCodeProducts
    {
        public List<Product> products;
        public HardCodeProducts()
        {
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Консультация по НИР", Price = 150, Image = "'../images/products/consul.png'" });
            //Product consul = 
            //Product course = new Product { Id = 2, Name = "Курсовая", Price = 4000, Image = "'../images/products/course.png'" };
            //Product diplom = new Product { Id = 3, Name = "Диплом", Price = 8000, Image = "'../images/products/diplom.png'" };
            //Product magister = new Product { Id = 4, Name = "Магистерская диссертация", Price = 14000, Image = "'../images/products/magister.png'" };
            //Product analyze = new Product { Id = 5, Name = "Комплексный анализ предприятия", Price = 4500, Image = "'../images/products/analyze.png'" };
            //Product practice = new Product { Id = 6, Name = "Отчет по практике", Price = 2000, Image = "'../images/products/practice.png'" };
            //Product busynesscredit = new Product { Id = 7, Name = "Бизнес-план для получения кредита", Price = 6000, Image = "'../images/products/businesscredit.png'" };
            //Product busynessinvest = new Product { Id = 8, Name = "Инвестиционный бизнес-план", Price = 4700, Image = "'../images/products/businesscredit.png'" };
        }
    }
}
