
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServices
{
    public interface IMessageSender
    {
        Task Send(string emailTo, string emailToname, string servicename, string subject, string message, string path, string emailfrom, string passwordfrom);
        Task Send(EmailType et);
    }
}
