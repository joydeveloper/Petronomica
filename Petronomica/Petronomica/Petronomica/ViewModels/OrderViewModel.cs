using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.ViewModels
{
    public class OrderViewModel
    {
      public OrderViewModel() { }
      public OrderViewModel(Orders.Order order)
        {
            OrderType = order.OrderType;
            OrderDate = order.OrderDate.Day+"."+order.OrderDate.Month.ToString()+"." + order.OrderDate.Year;
            OrderStatus = order.OrderStatus;
        }
        [Display(Name = "Тип заказа")]
        public string OrderType { get; set; }
        [Display(Name = "Дата")]
        public string OrderDate { get; set; }
        [Display(Name = "Статус")]
        public string OrderStatus { get; set; }
      
    }
}
