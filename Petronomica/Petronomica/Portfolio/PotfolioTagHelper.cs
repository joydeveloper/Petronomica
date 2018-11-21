using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio
{

    public class PortfolioTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public  PortfolioItem PortfolioItem { get; set; }
                public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
         $@"<div class='card-body'>
      <h4 class='text-muted alert {colors[i]}'>{PortfolioItem.Name}</h4>
      <div class='d-flex justify-content-between align-items-center'>
      </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-1 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
          
}
