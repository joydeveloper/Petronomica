using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog
{
    public class BlogListTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public BlogItem BlogItem { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var template =
           $@"<div class='jumbotron p-3 p-md-5 text-white rounded bg-dark'>
    <div class='col-md-6 px-0'>
  <h1 class='display-4 font-italic'>{BlogItem.Name}</h1>
               <p class='lead my-3'>{BlogItem.Short} </p>
            <p class='lead mb-0'><a href='Reader/Index?id={BlogItem.Id}' class='text-white font-weight-bold'>Продолжить читать...</a></p>
            </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class BlogItemTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "text-success", "text-warning", "text-primary" };
        public BlogItem BlogItem { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var template =
           $@"<div class='card flex-md-row mb-4 box-shadow h-md-250'>
            <div class='card-body d-flex flex-column align-items-start'>
                <strong class='d-inline-block mb-2 {colors[SetColor(BlogItem.Type)]}'>{BlogItem.Type}</strong>
                <h3 class='mb-0 text-dark'>
                    {BlogItem.Name}
                </h3>
                <div class='mb-1 text-muted'> {BlogItem.PublishDate.ToShortDateString()}</div>
                <p class='card-text mb-auto'>
                   {BlogItem.Short}
             </p>
                <a href = 'Reader/Index?id={BlogItem.Id}' > Продолжить читать...</a></div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "col-md-6");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
        private int SetColor(string type)
        {
            switch (type)
            {
                case "Общие": return 0;
                case "Разное": return 1;
                case "Учебные": return 2;
            }
            return 0;
        }
    }
   
   
    public class BlogMainTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public BlogItem BlogItem { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var template =
$@"<div class='jumbotron p-3 p-md-5 text-white rounded bg-dark'>
    <div class='col-md-6 px-0'>
  <h1 class='display-4 font-italic'>{BlogItem.Name}</h1>
               <p class='lead my-3'>{BlogItem.Short} </p>
            <p class='lead mb-0'><a href='Reader/Index?id={BlogItem.Id}' class='text-white font-weight-bold'>Продолжить читать...</a></p>
            </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
}

