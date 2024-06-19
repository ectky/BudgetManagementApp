using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetManagementApp.ViewModels
{
    public class AddBudgetToReportVM
    {
        public int BudgetId { get; set; }

        public int ReportId { get; set; }

        public IEnumerable<SelectListItem> ReportList { get; set; }
    }
}
