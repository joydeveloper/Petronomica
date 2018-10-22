using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
       // public User Userid { get; set; }
        public string Message { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
