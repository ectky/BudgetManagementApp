using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Dtos;

namespace BudgetManagementApp.ViewModels
{
    public class ReportDetailsVM : BaseVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<BudgetReportDto> BudgetReports { get; set; }
    }
}
