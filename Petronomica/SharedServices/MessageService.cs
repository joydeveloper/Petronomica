
using System.Threading.Tasks;

namespace SharedServices
{
    public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public async Task Send(string emailTo, string emailToname, string servicename, string subject, string message, string path, string emailfrom, string passwordfrom)
        {
            await _sender.Send(emailTo, emailToname, servicename, subject, message, path, emailfrom, passwordfrom);
        }
        public async Task Send(EmailType et)
        {
            await _sender.Send(et);
        }
    }
}
