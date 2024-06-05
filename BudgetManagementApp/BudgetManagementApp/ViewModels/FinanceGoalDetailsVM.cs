using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class FinanceGoalDetailsVM : BaseVM
    {
        public int BudgetId { get; set; }

        public  Budget Budget { get; set; }

        public decimal Amount { get; set; }

        public int UserId { get; set; }

        public  User User { get; set; }
    }
}
