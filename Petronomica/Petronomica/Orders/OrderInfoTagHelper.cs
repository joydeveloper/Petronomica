using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders
{
   
        public class OrderInfoTagHelper : TagHelper
        {
            public Order Order { get; set; }
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName = "div";

                string orderInfoContent = $@"<p>Номер: <b>{ Order.Id}</b></p>
                                    <p>Дата заказа: <b>{ Order.OrderDate}</b></p>
                                    <p>Тип услуги: <b>{ Order.OrderType}</b></p>
                                   <p>Статус услуги: <b>{ Order.OrderStatus}</b></p>";

                output.Content.SetHtmlContent(orderInfoContent);
            }
        }
   
}
