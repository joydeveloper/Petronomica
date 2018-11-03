using System;
using System.Threading.Tasks;

namespace SharedServices
{
    public class SmsMessageSender : IMessageSender
    {
        public async Task Send(string emailTo, string emailToname, string servicename, string subject, string message, string path, string emailfrom, string passwordfrom)
        {
            
        }

        public Task Send(EmailType et)
        {
            throw new NotImplementedException();
        }
    }
}
