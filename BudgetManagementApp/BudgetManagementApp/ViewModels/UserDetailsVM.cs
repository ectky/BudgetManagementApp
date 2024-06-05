using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class UserDetailsVM : BaseVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        
        public  List<BudgetDetailsVM> Budgets { get; set; }
        public  List<FinanceGoalDetailsVM> FinanceGoals { get; set; }
    }
}
