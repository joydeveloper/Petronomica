using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Models
{
    
    public class OrderDetail:ElementX.BaseX
    {
        public int Id { get; set; }
        public string Email { get; set; }
        // public string Email { get; set; }
        //public string Title { get; set; }
        public string Message { get; set; }
        //public DateTime AvailabilityPeriod { get; set; }
        //public bool Plan { get; set; }
        //public int WishMark { get; set; }
        //public bool Literature { get; set; }
        public string[] YFiles { get; set; }
    }
    public class ConsulDetail: OrderDetail
    {
      
        //public string Title { get; set; }
        //public DateTime AvailabilityPeriod { get; set; }
        //public bool Plan { get; set; }
        //public int WishMark { get; set; }
        //public bool Literature { get; set; }
    }
    public class CourseDetail: ConsulDetail
    {
        public bool Theme { get; set; }
        public bool Intro { get; set; }
        public bool Theory { get; set; }
        public bool Anal { get; set; }
        public bool Problems { get; set; }
        public bool Conclusion { get; set; }
        public string Title { get; set; }
        public DateTime AvailabilityPeriod { get; set; }
        public bool Plan { get; set; }
        public int WishMark { get; set; }
        public bool Literature { get; set; }
    }
    public class DiplomDetail : CourseDetail
    {
        public bool Referat { get; set; }
        public bool Presentation { get; set; }
        public bool PresentationReport { get; set; }
    }

}
