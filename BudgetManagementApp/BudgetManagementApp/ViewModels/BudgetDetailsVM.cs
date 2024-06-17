using BudgetManagement.Data.Entities;
using System.ComponentModel;

namespace BudgetManagementApp.ViewModels
{
    public class BudgetDetailsVM : BaseVM
    {
        public string Name { get; set; }

        
        public int BudgetCategoryId { get; set; }

        [DisplayName("Budget Category")]
        public BudgetCategoryDetailsVM BudgetCategory { get; set; }

        [DisplayName("Budget Amounts")]
        public  List<BudgetAmountDetailsVM> BudgetAmounts { get; set; }

        [DisplayName("Finance Goals")]
        public  List<FinanceGoalDetailsVM> FinanceGoals { get; set; } 

        public int UserId { get; set; }

        [DisplayName("User")]
        public  UserDetailsVM User { get; set; }
    }
}
