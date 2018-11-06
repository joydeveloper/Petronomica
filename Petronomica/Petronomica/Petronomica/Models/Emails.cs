using Microsoft.AspNetCore.Http;
using Petronomica.ViewModels;
using SharedServices;
using System;
using System.IO;
using System.Text;

namespace Petronomica.Models
{
    public class EMAILHARDCODE
    {
        public const string DEVMAIL = "development@petronomica.ru";
        public const string SERVICEMAIL = "development@petronomica.ru";

    }
    public class ConfirmEmail : EmailType
    {
        public ConfirmEmail(string emailto, string message)
        {
            Name = "Поддержка пользователей";
            From = "development@petronomica.ru";
            To = emailto;
            Subject = "Регистрация";
            Message = message;
            Password = "Toster12";
        }
    }
    public class ConsulPreOrderEmail : EmailType
    {
        public ConsulPreOrderEmail(int id, ConsulDetail cd,OrderViewModel orderViewModel, IFormFile[] files)
        {
            Name = "Петрономика";
            From = EMAILHARDCODE.SERVICEMAIL;
            To = cd.Email;
            Subject = "Предзаказ";
            Message = CreateMsg(id, cd, orderViewModel, files);
            Password = "Toster12";
        }
        private string BoolToRus(bool val)
        {
            if (val)
                return "Да";
            else
                return "Нет";
        }
        string CreateMsg(int id, ConsulDetail corder, OrderViewModel orderViewModel, IFormFile[] files)
        {
            try
            {
                int z = 0;
                corder.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    corder.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                AttachmentPath = corder.YFiles;
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<div>");
                sb.Append("</div>");
                sb.Append("<h3>"+orderViewModel.OrderStatus+" "+"№"+" " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + corder.Message + "</h3>");
                sb.Append("<hr>");
                return sb.ToString();
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>Предзаказ № " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + corder.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Статус:" + orderViewModel.OrderStatus + "</h3>");
                return sb.ToString();
            }
        }
    }
}


