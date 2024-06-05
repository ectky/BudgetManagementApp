using BudgetManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagementApp.ViewModels
{
    public class FinanceGoalEditVM : BaseVM
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [DisplayName("Budget")]
        public int BudgetId { get; set; }
        public IEnumerable<SelectListItem> BudgetsList { get; set; }
        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }
        public IEnumerable<SelectListItem> UsersList { get; set; }
    }
}
