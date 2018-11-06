using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.ViewModels
{
    public class ProductExtViewModel:Products.Product
    {
        public string ViewName { get; set; }
        public string Descript{ get; set; }
        public string MobilePath { get; set; }
        public string GlyphIcon { get; set; }
        public ProductExtViewModel(Products.Product product, string view, string descript, string imgpath, string mobilepath, string glyph)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Image = imgpath;
            ViewName = view;
            Descript = descript;
            MobilePath = mobilepath;
            GlyphIcon = glyph;
        }
        public ProductExtViewModel()
        { }
    }
}
