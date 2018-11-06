using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.ViewModels
{
    public class PreOrderViewModel
    {
        private static int _id;
        public PreOrderViewModel()
        {
            _id++;
            Id = _id;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime AvailabilityPeriod { get; set; }
        public bool Plan { get; set; }
        public int WishMark { get; set; }
        public bool Literature { get; set; }
        public string[] YFiles { get; set; }
    }
}
