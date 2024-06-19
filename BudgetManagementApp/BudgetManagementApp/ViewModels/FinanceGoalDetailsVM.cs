using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class FinanceGoalDetailsVM : BaseVM
    {
        public int BudgetId { get; set; }

        public  BudgetDetailsVM Budget { get; set; }

        public decimal Amount { get; set; }

        public  UserDetailsVM User { get; set; }
        public int UserId { get; set; }
        
        public string CompletionPercentage { get; set; }



    }
}
