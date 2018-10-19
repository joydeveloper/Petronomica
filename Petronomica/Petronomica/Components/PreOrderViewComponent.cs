using Petronomica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Components
{
    public class PreOrderViewComponent
    {
      
        public PreOrderViewComponent()
        {
           
        }
        public string Invoke()
        {
            return $"Ваш выбор:";
        }
    }
    public class PreOrder1ViewComponent
    {

        public PreOrder1ViewComponent()
        {

        }
        public string Invoke()
        {
            return $"Компонент 2";
        }
    }
}

