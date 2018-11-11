using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Models
{
    public class OrderDetail:ElementX.BaseX
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string[] YFiles { get; set; }
    }
    public class ConsulDetail: OrderDetail
    {
      
    }
    public class CourseDetail: ConsulDetail
    {
        public bool Theme { get; set; }
        public bool Intro { get; set; }
        public bool Theory { get; set; }
        public bool Anal { get; set; }
        public bool Problems { get; set; }
        public bool Conclusion { get; set; }
        public DateTime AvailabilityPeriod { get; set; }
        public bool Plan { get; set; }
        public int WishMark { get; set; }
        public bool Literature { get; set; }
    }
    public class DiplomaDetail : CourseDetail
    {
        public bool Referat { get; set; }
        public bool Presentation { get; set; }
        public bool PresentationReport { get; set; }
    }
    public class AFDetail : OrderDetail
    {

        public bool GorizontalA { get; set; }
        public bool GorizontalB { get; set; }
        public bool Liquid{ get; set; }
      //  public bool CapitalAnal { get; set; }
        public bool BusinessActivity{ get; set; }
        public bool FinancialCycle { get; set; }
       // public bool FinancialState { get; set; }
        public bool LuquidRatio { get; set; }
        public bool MoneyFlow { get; set; }
        public bool FinancialStability { get; set; }
        public bool MoneyFlowRatio { get; set; }
        public bool FinancialStabilityDefine { get; set; }
        public bool RelativeStability { get; set; }
        public bool RaitingCalc { get; set; }
        public bool FinresultReport { get; set; }
        public bool Profitability { get; set; }

    }
    public class SearchPaidDetail : OrderDetail
    {
        public string Infotype { get; set; }
        public DateTime dateTimePublication { get; set; }
        public string Sources { get; set; }
        public int SourcesCount { get; set; }
        public DateTime AvailabilityPeriod { get; set; }
    }

    public class BP : OrderDetail
    {
        public bool Intro { get; set; }
        public bool Conclusion { get; set; }
        public bool Marketing { get; set; }
        public bool ProductionPlan { get; set; }
        public bool Additional { get; set; }
        public bool AnalRisk { get; set; }
        public bool FinancialPlan { get; set; }
    }
    public class InvestBPDetail : BP
    {
        public bool FirmDescription { get; set; }
        public bool Production { get; set; }
        public bool Effective { get; set; }
       
    }
    public class CreditBPDetal : BP
    {
        public bool FirmStatus { get; set; }
        public bool Industry { get; set; }
        public bool MarketAnal{ get; set; }
        public bool Economic { get; set; }
        public bool PaidCalendar { get; set; }
        public bool Effective { get; set; }

    }
}
