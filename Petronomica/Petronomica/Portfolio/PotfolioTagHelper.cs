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
    $@"<div class='jumbotron'>
            <p class='card-text'>{PortfolioItem.Name}</p>
              <div class='d-flex justify-content-between align-items-center'>
                     <img id='{PortfolioItem.IdEmployee}'  class='card-img-right' onclick='PoductConfig({PortfolioItem.Path})'  style='cursor:pointer' src={PortfolioItem.Rating}/>
              </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-1 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
   
}
