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
    public class WishEmail : EmailType
    {
        public WishEmail(string emailto, string message)
        {
            Name = "Пожелания и предложения";
            From = "development@petronomica.ru";
            To = "development@petronomica.ru";
            Subject = "Пожелание "+emailto;
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
            //try
            //{
            //    int z = 0;
            //    _details.YFiles = new string[files.Length];
            //    foreach (IFormFile doc in files)
            //    {
            //        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userfiles", doc.FileName);
            //        _details.YFiles[z] = path;
            //        z++;
            //    }
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
    public class PracticeReportPreOrderEmail : PreOrderEmail<PracticeReportDetail>
    {
        public PracticeReportPreOrderEmail(int id, PracticeReportDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
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
                sb.Append("<h3>Тема - " + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Анализ фирмы - " + BoolToRus(_details.FirmAnal) + "</h3>");
         

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
                sb.Append("<h3>Тема-" + BoolToRus(_details.Theme) + "</h3>");
                sb.Append("<h3>Анализ фирмы" + BoolToRus(_details.FirmAnal) + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
    public class SearchPreOrderEmail : PreOrderEmail<SearchPaidDetail>
    {
        public SearchPreOrderEmail(int id, SearchPaidDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
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
                sb.Append("<h3>Вид информации-" + _details.Infotype + "</h3>");
                sb.Append("<h3>Год публикации(не позднее)" + _details.dateTimePublication + "</h3>");
                sb.Append("<h3>Источники" + _details.Sources + "</h3>");
                sb.Append("<h3>Количество источников" + _details.SourcesCount + "</h3>");
                sb.Append("<h3>Срок готовности к" + _details.AvailabilityPeriod + "</h3>");
  
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
                sb.Append("<h3>Вид информации-" + _details.Infotype + "</h3>");
                sb.Append("<h3>Год публикации(не позднее)" + _details.dateTimePublication + "</h3>");
                sb.Append("<h3>Источники" + _details.Sources + "</h3>");
                sb.Append("<h3>Количество источников" + _details.SourcesCount + "</h3>");
                sb.Append("<h3>Срок готовности к" + _details.AvailabilityPeriod + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
    public class AFPreOrderEmail : PreOrderEmail<AFDetail>
    {
        public AFPreOrderEmail(int id, AFDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
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
                sb.Append("<h3>Горизонтальный(временный) - " + BoolToRus(_details.GorizontalA) + "</h3>");
                sb.Append("<h3>Вертикальный(структурный) -  " + BoolToRus(_details.GorizontalB) + "</h3>");
                sb.Append("<h3>Анализ ликвидности -  " + BoolToRus(_details.Liquid) + "</h3>");
                sb.Append("<h3>Анализ оборачиваемости - " + BoolToRus(_details.BusinessActivity) + "</h3>");
                sb.Append("<h3>Характеристика этапов финансового цикла - " + BoolToRus(_details.FinancialCycle) + "</h3>");
                sb.Append("<h3>Показатели ликвидности и платежеспособности - " + BoolToRus(_details.LuquidRatio) + "</h3>");
                sb.Append("<h3>Показатели достаточности денежного потока - " + BoolToRus(_details.MoneyFlow) + "</h3>");
                sb.Append("<h3>Определение типа финансовой устойчивости - " + BoolToRus(_details.FinancialStabilityDefine)+ "</h3>");
                sb.Append("<h3>Анализ относительных показателей финансовой устойчивости - " + _details.RelativeStability + "</h3>");
                sb.Append("<h3>Расчет рейтинга заемщика - " + _details.RaitingCalc + "</h3>");
                sb.Append("<h3>Анализ отчета о прибылях и убытках - " + _details.FinresultReport + "</h3>");
                sb.Append("<h3>Анализ рентабельности - " + _details.Profitability+ "</h3>");
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
                sb.Append("<h3>Горизонтальный(временный) - " + BoolToRus(_details.GorizontalA) + "</h3>");
                sb.Append("<h3>Вертикальный(структурный) -  " + BoolToRus(_details.GorizontalB) + "</h3>");
                sb.Append("<h3>Анализ ликвидности -  " + BoolToRus(_details.Liquid) + "</h3>");
                sb.Append("<h3>Анализ оборачиваемости - " + BoolToRus(_details.BusinessActivity) + "</h3>");
                sb.Append("<h3>Характеристика этапов финансового цикла - " + BoolToRus(_details.FinancialCycle) + "</h3>");
                sb.Append("<h3>Показатели ликвидности и платежеспособности - " + BoolToRus(_details.LuquidRatio) + "</h3>");
                sb.Append("<h3>Показатели достаточности денежного потока - " + BoolToRus(_details.MoneyFlow) + "</h3>");
                sb.Append("<h3>Определение типа финансовой устойчивости - " + BoolToRus(_details.FinancialStabilityDefine) + "</h3>");
                sb.Append("<h3>Анализ относительных показателей финансовой устойчивости - " + _details.RelativeStability + "</h3>");
                sb.Append("<h3>Расчет рейтинга заемщика - " + _details.RaitingCalc + "</h3>");
                sb.Append("<h3>Анализ отчета о прибылях и убытках - " + _details.FinresultReport + "</h3>");
                sb.Append("<h3>Анализ рентабельности - " + _details.Profitability + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
    public class CreditBPPreOrderEmail : PreOrderEmail<CreditBPDetail>
    {
        public CreditBPPreOrderEmail(int id,CreditBPDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
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
                sb.Append("<h3>Резюме" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Юридический статус организации - " + BoolToRus(_details.FirmStatus) + "</h3>");
                sb.Append("<h3>Характеристика отрасли - " + BoolToRus(_details.Industry) + "</h3>");
                sb.Append("<h3>Анализ рынка - " + BoolToRus(_details.MarketAnal) + "</h3>");
                sb.Append("<h3>Маркетинговый план - " + BoolToRus(_details.Marketing) + "</h3>");
                sb.Append("<h3>Экономика предприятия - " + BoolToRus(_details.Economic) + "</h3>");
                sb.Append("<h3>Финансовый план - " + BoolToRus(_details.FinancialPlan) + "</h3>");
                sb.Append("<h3>Производственный план - " + BoolToRus(_details.ProductionPlan) + "</h3>");
                sb.Append("<h3>Платёжный календарь" + BoolToRus(_details.PaidCalendar) + "</h3>");
                sb.Append("<h3>заключение - " + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Дополнительно - " + BoolToRus(_details.Conclusion) + "</h3>");              
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
                sb.Append("<h3>Резюме" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Юридический статус организации - " + BoolToRus(_details.FirmStatus) + "</h3>");
                sb.Append("<h3>Характеристика отрасли - " + BoolToRus(_details.Industry) + "</h3>");
                sb.Append("<h3>Анализ рынка - " + BoolToRus(_details.MarketAnal) + "</h3>");
                sb.Append("<h3>Маркетинговый план - " + BoolToRus(_details.Marketing) + "</h3>");
                sb.Append("<h3>Экономика предприятия - " + BoolToRus(_details.Economic) + "</h3>");
                sb.Append("<h3>Финансовый план - " + BoolToRus(_details.FinancialPlan) + "</h3>");
                sb.Append("<h3>Производственный план - " + BoolToRus(_details.ProductionPlan) + "</h3>");
                sb.Append("<h3>Платёжный календарь" + BoolToRus(_details.PaidCalendar) + "</h3>");
                sb.Append("<h3>заключение - " + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Дополнительно - " + BoolToRus(_details.Conclusion) + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
    public class InvestBPPreOrderEmail : PreOrderEmail<InvestBPDetail>
    {
        public InvestBPPreOrderEmail(int id, InvestBPDetail cd, OrderViewModel orderViewModel, IFormFile[] files) : base(id, cd, orderViewModel, files)
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
                sb.Append("<h3>Краткая характеристика инвестиционного проекта" + BoolToRus(_details.Intro) + "</h3>");
                sb.Append("<h3>Описание предприятия" + BoolToRus(_details.FirmDescription) + "</h3>");
                sb.Append("<h3>Описание продукции" + BoolToRus(_details.Production) + "</h3>");
                sb.Append("<h3>Маркетинг и сбыт продукции" + BoolToRus(_details.Marketing) + "</h3>");
                sb.Append("<h3>Производственный план" + BoolToRus(_details.ProductionPlan) + "</h3>");
                sb.Append("<h3>Финансовый план" + BoolToRus(_details.FinancialPlan) + "</h3>");
                sb.Append("<h3>Эффективность проекта" + BoolToRus(_details.Effective) + "</h3>");
                sb.Append("<h3>Анализ и оценка рисков" + BoolToRus(_details.AnalRisk) + "</h3>");
                sb.Append("<h3>Заключение" + BoolToRus(_details.Conclusion) + "</h3>");
                sb.Append("<h3>Приложения" + BoolToRus(_details.Additional) + "</h3>");
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
                sb.Append("<h3>Краткая характеристика инвестиционного проекта" + _details.Intro + "</h3>");
                sb.Append("<h3>Описание предприятия" + _details.FirmDescription + "</h3>");
                sb.Append("<h3>Описание продукции" + _details.Production + "</h3>");
                sb.Append("<h3>Маркетинг и сбыт продукции" + _details.Marketing + "</h3>");
                sb.Append("<h3>Производственный план" + _details.ProductionPlan + "</h3>");
                sb.Append("<h3>Финансовый план" + _details.FinancialPlan + "</h3>");
                sb.Append("<h3>Эффективность проекта" + _details.Effective + "</h3>");
                sb.Append("<h3>Анализ и оценка рисков" + _details.AnalRisk + "</h3>");
                sb.Append("<h3>Заключение" + _details.Conclusion + "</h3>");
                sb.Append("<h3>Приложения" + _details.Additional + "</h3>");
                _details.Message += sb.ToString();
                return sb.ToString();
            }
        }
    }
}


