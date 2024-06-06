using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class BudgetDetailsVM : BaseVM
    {
        public string Name { get; set; }

        
        public int BudgetCategoryId { get; set; }
        public BudgetCategoryDetailsVM BudgetCategory { get; set; }

        public  List<BudgetAmountDetailsVM> BudgetAmounts { get; set; } 
        public  List<FinanceGoalDetailsVM> FinanceGoals { get; set; } 

        public int UserId { get; set; }
        public  UserDetailsVM User { get; set; }
        


    }
}
