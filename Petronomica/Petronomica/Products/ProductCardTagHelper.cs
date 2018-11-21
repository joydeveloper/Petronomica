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
             <img id='{Product.Id}'  class='card-img-right' onclick='PoductConfig({Product.Id})'  style='cursor:pointer' src={Product.Image}/>
                 <h7 class='text-muted alert {colors[i]}'>От {Product.Price} рублей</h7>
      </div>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
      
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class ProductCardaTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<div class='card'><div class='card-body'>
    <img class='card-img-top' src={Product.Image} alt='Card image'  onclick='PreOrder({Product.Id})' style='width:10%;height:10%;cursor:pointer'/>
    <div class='card-img-overlay'>
      <p class='card-text'>От {Product.Price} рублей</p>
    </div>
  </div></div>";

              output.TagName = "div";
            output.Attributes.SetAttribute("class", "card mb-6 shadow-sm");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class ProductCardbTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        string[] topcolors= new string[] { "#E74431", "#E0F383", "#95E7F1", "#BC96EA"};
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<img class='card-img-top' style='background-color:{topcolors[i]};cursor:pointer' onclick='PreOrder({Product.Id})'>
              <div class='card-body'>
            <h5 class='card-title'>{Product.Name}</h5>
            <p class='card-text'>Цена от</p>
            <small class='text-muted'>{Product.Price} рублей</small></p>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card ");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class ProductCardcssTagHelper : TagHelper
    {
        string css ="backgroundcard";
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<img class='card-img-top' style='cursor:pointer' src={Product.Image} alt={Product.Id}  onclick='ProductConfig({Product.Id})' onmouseover='CardAnimOver(this)' onmouseout='CardAnimLost(this)'>
        <div class='card-body {css}'  onclick='PreOrder({Product.Id})';>
            <h5 class='card-title'>{Product.Name}</h5>
            <p class='card-text'>Цена  </p>
             <div class='card-footer'>
             <h5 class='text-muted alert {colors[i]}'>От {Product.Price} рублей</h5>
        </div>";

               output.TagName = "div";
            output.Attributes.SetAttribute("class", "card");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class ProductCardoverlayTagHelper : TagHelper
    {
        string css = "backgroundcard";
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<img class='card-img-top'   src={Product.Image} alt={Product.Id}>
         <div class='card-img-overlay'>
          <h4 class='card-title'>John Doe</h4>
      <p class='card-text'>Some example text some example text.Some example text some example text.Some example text some example text. Some example text some example text.</p>
      <a href = '#' class='btn btn-primary'>See Profile</a>
      </div>";

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card img-fluid");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class ProductCardbuttongroupTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        string[] topcolors = new string[] { "#E74431", "#E0F383", "#95E7F1", "#BC96EA" };
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<div class='btn-group mr-2' role='group' aria-label='First group'>
    <button type='button' class='btn btn-secondary'>Предзаказ</button>
    <button type ='button' class='btn btn-secondary'>Заказ</button>
    <button type ='button' class='btn btn-secondary'>Конструктор</button>
  </div>
            <div class='card-body'>
            <h5 class='card-title'>{Product.Name}</h5>
            <p class='card-text'>Цена от</p>
            <small class='text-muted'>{Product.Price} рублей</small></p>
        ";

            output.TagName = "div";
            output.Attributes.SetAttribute("class","card");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
    public class ProductCardbestTagHelper : TagHelper
    {
        Random rand = new Random();
        int i;
        string[] colors = new string[] { "alert-success", "alert-warning", "alert-primary", "alert-danger", "alert-light" };
        string[] topcolors = new string[] { "#C4EEC0", "#C0EEEA", "#C0EEEA", "#D1ECF5" };
        public Product Product { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            i = rand.Next(0, 4);
            var template =
$@"<img class='card-img-top' style='background-color:{topcolors[i]};cursor:pointer;box-shadow:0px 0px 0px 2px #9fb4f2;' onclick='PreOrder({Product.Id})' onmouseover='CardAnimOver(this)' onmouseout='CardAnimLost(this)'>
              <div class='card-body'>
            <h5 class='card-title'>{Product.Name}</h5>
            <h7 class='card-text'>Цена</h7>
            <h5 class='text-muted alert {colors[i]}'>От {Product.Price} рублей</h5>";
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "card ");
            output.Content.AppendHtml(template);
            output.Content.AppendHtml("</div>");
        }
    }
}
