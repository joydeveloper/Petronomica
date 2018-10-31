using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.ViewModels
{
    public class ProductExtViewModel:Products.Product
    {
        public string Descript{ get; set; }
        public string MobilePath { get; set; }
        public string GlyphIcon { get; set; }
    }
}
