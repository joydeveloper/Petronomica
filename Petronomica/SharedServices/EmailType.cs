using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public abstract class EmailType
    {
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string[] AttachmentPath { get; set; }
        public string Password;
    }
}
