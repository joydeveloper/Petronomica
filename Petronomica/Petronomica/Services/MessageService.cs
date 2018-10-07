using Petronomica.Models;
using System.Threading.Tasks;

namespace Petronomica.Services
{
    public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public async Task Send(string email, string subject, string message, string path)
        {
            await _sender.Send(email,subject,message,path);
        }
        public async Task Send(EmailType et)
        {
            await _sender.Send(et);
        }
    }
}
