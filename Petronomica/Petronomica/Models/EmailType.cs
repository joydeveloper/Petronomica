using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Models
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
    public class TestEmail : EmailType
    {
        public TestEmail()
        {
            Name = "Разработчик";
            From = "development@petronomica.ru";
            To = "joy2431@list.ru";
            Subject = "Test";
            Message = "Test message";
            Password = "Toster12";
        }

    }
    public class ValidationEmail : EmailType
    {
        public ValidationEmail(string email, string msg)
        {
            Name = "Petronomica";
            From = "development@petronomica.ru";
            To = email;
            Subject = "Подтверждение аккаунта";
            Message = msg;
            Password = "Toster12";

        }
    }
    public class TestConstOrderEmail : TestEmail
    {

        public TestConstOrderEmail(string message, string[] attach) : base()
        {
            Message = message;
            AttachmentPath = attach;
        }
    }
    public class PreOrderEmail:EmailType
        {
        public PreOrderEmail(PreOrder preOrder)
        {
            Name = "Petronomica";
            From = "development@petronomica.ru";
            To = preOrder.Email;
            Subject = "Предзаказ "+preOrder.Title;
            Message = preOrder.Message;
            AttachmentPath = preOrder.YFiles;
            Password = "Toster12";
        }
        }
    public class PreOrderEmailReport : EmailType
    {
        public PreOrderEmailReport(PreOrder preOrder)
        {
            Name = "Petronomica";
            From = "development@petronomica.ru";
            To = "development@petronomica.ru"; //petr_abramov_1991@mail.ru
            Subject = "Предзаказ " + preOrder.Title;
            Message = preOrder.Message;
            AttachmentPath = preOrder.YFiles;
            Password = "Toster12";
        }
    }
}
