using BudgetManagement.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagementApp.ViewModels
{
    public class BudgetEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Budget Category")]
        public int BudgetCategoryId { get; set; }
        [Required]
        public BudgetCategory BudgetCategories { get; set; }
        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}
