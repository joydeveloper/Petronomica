using Containers;
using System;
using System.Collections.Generic;

namespace Blog
{
    public class BlogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Path { get; set; }
        public DateTime PublishDate { get; set; }
    }
    public class BlogItemContainer: Switcher<BlogItem>
    {
        public BlogItemContainer(List<BlogItem> bi):base(bi)
        {

        }

    }
}
