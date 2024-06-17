using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class BudgetCategoryDetailsVM : BaseVM
    {

        public string Name { get; set; }
        public  List<BudgetDetailsVM> Budgets { get; set; }

    }
}
