using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Blog;

namespace PetronomicaServices
{
    public class BlogService
    {
        IBlogRepo _blogcontrol;
    }
}
public interface IBlogRepo
{ 
    Task<BlogItemContainer> GetArticlesAsync();
}
public class HardCodeBlogRepository : IBlogRepo
{
   HardCodeData.HardCodeBlog hcb = new HardCodeData.HardCodeBlog(Directory.GetFiles("wwwroot/articles/", "*.html"));  
 
    public async Task<BlogItemContainer> GetArticlesAsync()
    {
        return await Task.Run(() => hcb.blogItemContainer);
    }
}
