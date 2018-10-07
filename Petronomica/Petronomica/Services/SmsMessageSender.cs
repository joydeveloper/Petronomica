using Petronomica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public async Task Send(string email, string subject, string message, string path)
        {
            
        }

        public Task Send(EmailType et)
        {
            throw new NotImplementedException();
        }
    }
}
