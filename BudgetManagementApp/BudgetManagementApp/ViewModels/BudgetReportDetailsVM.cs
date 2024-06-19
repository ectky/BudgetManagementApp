namespace BudgetManagementApp.ViewModels
{
    public class BudgetReportDetailsVM : BaseVM
    {
        public BudgetDetailsVM Budget { get; set; }

        public ReportDetailsVM Report { get; set; }

        public int BudgetId { get; set; }

        public int ReportId { get; set; }
    }
}
