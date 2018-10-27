using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class ProductCardTagHelper : TagHelper
    {
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var template =
$@"<div class='card-body'>
    <p class='card-text'>{Product.Name}</p>
      <div class='d-flex justify-content-between align-items-center'>
             <img id='{Product.Id}' class='card-img-right' onclick='PreOrder({Product.Id})'  style='cursor:pointer' src={Product.Image}/>
                 <h5 class='text-muted alert alert-info'>От {Product.Price} рублей</h5>
      </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
}
