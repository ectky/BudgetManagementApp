using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class ReportDetailsVM : BaseVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public  List<BudgetDetailsVM> Budgets { get; set; }
    }
}
