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
    public abstract class PreOrderEmail<T>:EmailType 
    {
       protected abstract string CreateMsg(int id,OrderViewModel orderViewModel, IFormFile[] files);
       public T _details;
       public PreOrderEmail(int id, T cd, OrderViewModel orderViewModel, IFormFile[] files)
        {
            Name = "Петрономика";
            From = EMAILHARDCODE.SERVICEMAIL;
            Subject = "Предзаказ";
            _details = cd;
            Message = CreateMsg(id,orderViewModel, files);
            Password = "Toster12";
  
        }
        protected string BoolToRus(bool val)
        {
            if (val)
                return "Да";
            else
                return "Нет";
        }
    }
    public class ConsulPreOrderEmail : PreOrderEmail<ConsulDetail>
    {
        public ConsulPreOrderEmail(int id, ConsulDetail cd,OrderViewModel orderViewModel, IFormFile[] files) : base(id,cd,orderViewModel,files)
        {
            To = cd.Email;
            //_details = cd;
        }
        protected override string CreateMsg(int id, OrderViewModel orderViewModel, IFormFile[] files)
        {
            try
            {
                int z = 0;
                _details.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    _details.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                AttachmentPath = _details.YFiles;
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<div>");
                sb.Append("</div>");
                sb.Append("<h3>"+orderViewModel.OrderStatus+" "+"№"+" " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
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
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Статус:" + orderViewModel.OrderStatus + "</h3>");
                return sb.ToString();
            }
        }
    }
    public class CoursePreOrderEmail : PreOrderEmail<CourseDetail>
    {
        public CoursePreOrderEmail(int id, CourseDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
        {
            To = cd.Email;
        }
        protected override string CreateMsg(int id, OrderViewModel orderViewModel, IFormFile[] files)
        {
            try
            {
                int z = 0;
                _details.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    _details.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                AttachmentPath = _details.YFiles;
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>"+orderViewModel.OrderStatus+ "№ " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Адрес электронной почты:" + _details.Email + "</h3>");
                sb.Append("<h3>Тема курсовой/ дипломной работы-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(_details.Plan) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(_details.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(_details.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(_details.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(_details.Literature) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + _details.WishMark + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>" + orderViewModel.OrderStatus + "№ " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Адрес электронной почты:" + _details.Email + "</h3>");
                sb.Append("<h3>Тема курсовой работы-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(_details.Plan) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(_details.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(_details.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(_details.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(_details.Literature) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + _details.WishMark + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
    public class DiplomaPreOrderEmail : PreOrderEmail<DiplomaDetail>
    {
        public DiplomaPreOrderEmail(int id, DiplomaDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
        {
            To = cd.Email;
        }
        protected override string CreateMsg(int id, OrderViewModel orderViewModel, IFormFile[] files)
        {
            try
            {
                int z = 0;
                _details.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    _details.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>" + orderViewModel.OrderStatus + "№ " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Адрес электронной почты:" + _details.Email + "</h3>");
                sb.Append("<h3>Тема дипломной работы-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(_details.Plan) + "</h3>");
                sb.Append("<h3>Реферат-" + BoolToRus(_details.Referat) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(_details.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(_details.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(_details.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(_details.Literature) + "</h3>");
                sb.Append("<h3>Презентация-" + BoolToRus(_details.Presentation) + "</h3>");
                sb.Append("<h3>Доклад к презентации-" + BoolToRus(_details.PresentationReport) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + _details.WishMark + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>" + orderViewModel.OrderStatus + "№ " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Адрес электронной почты:" + _details.Email + "</h3>");
                sb.Append("<h3>Тема курсовой/ дипломной работы-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(_details.Plan) + "</h3>");
                sb.Append("<h3>Реферат-" + BoolToRus(_details.Referat) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(_details.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(_details.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(_details.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(_details.Literature) + "</h3>");
                sb.Append("<h3>Презентация-" + BoolToRus(_details.Presentation) + "</h3>");
                sb.Append("<h3>Доклад к презентации-" + BoolToRus(_details.PresentationReport) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + _details.WishMark + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
    public class MagisterPreOrderEmail : PreOrderEmail<DiplomaDetail>
    {
        public MagisterPreOrderEmail(int id, DiplomaDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
        {
            To = cd.Email;
        }
        protected override string CreateMsg(int id, OrderViewModel orderViewModel, IFormFile[] files)
        {
            try
            {
                int z = 0;
                _details.YFiles = new string[files.Length];
                foreach (IFormFile doc in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    doc.CopyToAsync(stream);
                    _details.YFiles[z] = path;
                    stream.Close();
                    z++;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>" + orderViewModel.OrderStatus + "№ " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Адрес электронной почты:" + _details.Email + "</h3>");
                sb.Append("<h3>Тема диссертации-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(_details.Plan) + "</h3>");
                sb.Append("<h3>Реферат-" + BoolToRus(_details.Referat) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(_details.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(_details.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(_details.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(_details.Literature) + "</h3>");
                sb.Append("<h3>Презентация-" + BoolToRus(_details.Presentation) + "</h3>");
                sb.Append("<h3>Доклад к презентации-" + BoolToRus(_details.PresentationReport) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + _details.WishMark + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<hr><hr>");
                sb.Append("<div>");
                sb.Append("<h3 style='text-align:right;'>Дата:" + orderViewModel.OrderDate + "</h3>");
                sb.Append("</div>");
                sb.Append("<h3>" + orderViewModel.OrderStatus + "№ " + id + "</h3>");
                sb.Append("<h3>Тип:" + orderViewModel.OrderType + "</h3>");
                sb.Append("<h3>Ваш вопрос:" + _details.Message + "</h3>");
                sb.Append("<hr>");
                sb.Append("<h3>Адрес электронной почты:" + _details.Email + "</h3>");
                sb.Append("<h3>Тема курсовой/ дипломной работы-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Содержание/ план работы-" + BoolToRus(_details.Plan) + "</h3>");
                sb.Append("<h3>Реферат-" + BoolToRus(_details.Referat) + "</h3>");
                sb.Append("<h3>Введение-" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Теоретическая часть работы-" + BoolToRus(_details.Theory) + "</h3>");
                sb.Append("<h3>Аналитическая часть работы-" + BoolToRus(_details.Anal) + "</h3>");
                sb.Append("<h3>Проблемы и совершенствование предмета исследования-" + BoolToRus(_details.Problems) + "</h3>");
                sb.Append("<h3>Заключение-" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Список используемой литературы-" + BoolToRus(_details.Literature) + "</h3>");
                sb.Append("<h3>Презентация-" + BoolToRus(_details.Presentation) + "</h3>");
                sb.Append("<h3>Доклад к презентации-" + BoolToRus(_details.PresentationReport) + "</h3>");
                sb.Append("<h3>Желаемая оценка-" + _details.WishMark + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
}


