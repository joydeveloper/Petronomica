using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SharedServices
{
    public class EmailMessageSender : IMessageSender
    {
        const string emailsmtp = "smtp.yandex.ru";
        const int smtpport = 465;
        public async Task Send(string emailTo,string emailToname,string servicename, string subject, string message, string path,string emailfrom,string passwordfrom)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(servicename, emailfrom));
            emailMessage.To.Add(new MailboxAddress(emailToname, emailTo));
            emailMessage.Subject = subject;
            var builder = new BodyBuilder();
            builder.TextBody = message;
            string ex;
            try
            {
                builder.Attachments.Add(path);
            }
            catch (Exception e)
            {
                ex = e.ToString();
            }
            emailMessage.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(emailsmtp, smtpport, false);
                await client.AuthenticateAsync(emailfrom, passwordfrom);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
       
        public async Task Send(EmailType et)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "logo2.png");
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(et.Name, et.From));
            emailMessage.To.Add(new MailboxAddress("", et.To));
            emailMessage.Subject = et.Subject;
            var builder = new BodyBuilder();
            try
            {
                if (et.AttachmentPath != null)
                    foreach (string s in et.AttachmentPath)
                    {
                        builder.Attachments.Add(s);
                    }
                var image = builder.LinkedResources.Add(path);
                image.ContentId = MimeUtils.GenerateMessageId();
                builder.HtmlBody = string.Format(@"<center><img src=""cid:{0}""></center>", image.ContentId)+et.Message;
            }
            catch (Exception e)
            {

            }
            emailMessage.Body = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(emailsmtp, smtpport, true);
                await client.AuthenticateAsync(et.From, et.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
