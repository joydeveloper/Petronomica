using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using Petronomica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Services
{

    public class EmailMessageSender : IMessageSender
    {

        public async Task Send(string email, string subject, string message, string path)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Sender service", "development@petronomica.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = @"Hey Alice,

What are you up to this weekend? Monica is throwing one of her parties on
Saturday and I was hoping you could make it.

Will you be my +1?

-- Joey
";
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
                await client.ConnectAsync("smtp.yandex.ru", 465, false);
                await client.AuthenticateAsync("development@petronomica.ru", "Toster12");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }

        }
        public async Task Send(EmailType et)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(et.Name, et.From));
            emailMessage.To.Add(new MailboxAddress("", et.To));
            emailMessage.Subject = et.Subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text =et.Message
            //};
            var builder = new BodyBuilder();
           // builder.TextBody = et.Message;
    
            try
            {
                if (et.AttachmentPath != null)
                    foreach (string s in et.AttachmentPath)
                    {
                        builder.Attachments.Add(s);
                    }
                builder.HtmlBody = et.Message;
            }
            catch (Exception e)
            {

            }
            emailMessage.Body = builder.ToMessageBody();
        // .Attachments = builder.ToMessageBody();
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                await client.AuthenticateAsync(et.From, et.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

        }
    }
}
