using Petronomica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Services
{
    public interface IMessageSender
    {
        Task Send(string email, string subject, string message, string path);
        Task Send(EmailType et);
    }
}
