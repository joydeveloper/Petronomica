using Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardCodeData
{
    public class HardCodeBlog
    {
        private List<BlogItem> articles;
        public BlogItemContainer blogItemContainer;
        public HardCodeBlog()
        {
            articles = new List<BlogItem>();
            articles.Add(new BlogItem { Id = 1 ,});
            blogItemContainer = new BlogItemContainer(articles);
        }
        public HardCodeBlog(string[] paths)
        {
            articles = new List<BlogItem>();
            int i = 0;
            foreach (string path in paths)
            {

                articles.Add(new BlogItem { Id = i, Name = paths[i], Path = paths[i], PublishDate = DateTime.Now,Type=GetArticleType(path) });
                i++;
            }
            blogItemContainer = new BlogItemContainer(articles);
        }
        private string GetArticleType(string s)
        {
            s = s.Substring(s.Length - 1);
            switch(s)
            {
                case "S":return "Общие";
                case "M": return "Разное";
                case "L": return "Учебные";
            }
            return "Общие";
        }
    }
}
