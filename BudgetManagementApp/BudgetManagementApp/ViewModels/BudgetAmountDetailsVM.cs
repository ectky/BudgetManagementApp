using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Enums;

namespace BudgetManagementApp.ViewModels
{
    public class BudgetAmountDetailsVM : BaseVM
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int BudgetId { get; set; }

        public  BudgetDetailsVM Budget { get; set; }

        public BudgetType Type { get; set; }
    }
}
