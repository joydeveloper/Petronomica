using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Models
{
    public abstract class PreOrder
    {
        private static int _id;
        public PreOrder()
        {
            _id++;
            Id = _id;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Plan { get; set; }
        public int WishMark { get; set; }
        public bool Literature { get; set; }
    }
    public class CourseWorkPreOrder : PreOrder
    {
        public bool Theme { get; set; }
        public bool Intro { get; set; }
        public bool Theory { get; set; }
        public bool Anal { get; set; }
        public bool Problems { get; set; }
        public bool Conclusion { get; set; }
       
        public List<string> YFiles { get; set; }
    }
    public class DiplomPreOrder : CourseWorkPreOrder
    {
        public bool Referat{ get; set; }
        public bool Presentation { get; set; }
        public bool PresentationReport { get; set; }
    }
    public class PracticeReportPreOrder:PreOrder
    {
        public bool Theme { get; set; }
        public bool FirmAnal { get; set; }
        public bool Commet { get; set; }
    }
}
