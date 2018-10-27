using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class ProductCardTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors= new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<div class='card-body'>
    <p class='card-text'>{Product.Name}</p>
      <div class='d-flex justify-content-between align-items-center'>
             <img id='{Product.Id}'  class='card-img-right' onclick='PreOrder({Product.Id})'  style='cursor:pointer' src={Product.Image}/>
                 <h7 class='text-muted alert {colors[i]}'>От {Product.Price} рублей</h7>
      </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
}
