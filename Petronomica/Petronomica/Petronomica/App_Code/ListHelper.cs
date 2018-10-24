using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HtmlHelpersApp.App_Code
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            string result = "<ul>";
            foreach (string item in items)
            {
                result += $"<li>{item}</li>";
            }
            result += "</ul>";
            return new HtmlString(result);
        }
        public static HtmlString CreateA(this IHtmlHelper html, string[] items)
        {
            string result = "<ol>";
            foreach (string item in items)
            {
                result += $"<li><a href={item} target='_blank'>{item}</a></li>";
            }
            result += "</ol>";
            return new HtmlString(result);
        }
    }
}
