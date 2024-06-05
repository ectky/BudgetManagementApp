using BudgetManagement.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagementApp.ViewModels
{
    public class FinanceGoalEditVM : BaseVM
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public User User { get; set; }
    }
}
