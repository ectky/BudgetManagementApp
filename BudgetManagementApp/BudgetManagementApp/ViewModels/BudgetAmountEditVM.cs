using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BudgetManagementApp.ViewModels
{
    public class BudgetAmountEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [DisplayName("Budget")]
        public int BudgetId { get; set; }
        [Required]
        public Budget Budget { get; set; }
        [Required]
        public BudgetType Type { get; set; }
    }
}
