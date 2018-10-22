using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Models
{
    public class ConstOrder
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Theme { get; set; }
        public bool Plan { get; set; }
        public bool Referat { get; set; }
        public bool Intro { get; set; }
        public bool Theory { get; set; }
        public bool Anal { get; set; }
        public bool Problems { get; set; }
        public bool Conclusion { get; set; }
        public bool Literature { get; set; }
        public bool Presentation { get; set; }
        public bool PresentationReport { get; set; }
        public int WishMark { get; set; }
        public List<string> YFiles { get; set; }
    }
}
