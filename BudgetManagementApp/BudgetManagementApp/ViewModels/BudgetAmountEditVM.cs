using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> BudgetsList { get; set; }
        [Required]
        public BudgetType Type { get; set; }



    }
}
