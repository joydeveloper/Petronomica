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
            articles.Add(new BlogItem { Id = 1 });
            blogItemContainer = new BlogItemContainer(articles);
        }

    }
}
