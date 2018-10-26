using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products
{
    public class ProductCardTagHelper:TagHelper
    {
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var template =
$@"<div class='card-body'>
    <p class='card-text'>{Product.Name}</p>
      <div class='d-flex justify-content-between align-items-center'>
       
        <h5 class='text-muted alert alert-info'>{Product.Price}</h5>
      </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
}
 