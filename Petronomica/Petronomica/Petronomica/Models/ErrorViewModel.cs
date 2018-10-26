using System;

namespace Petronomica.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}