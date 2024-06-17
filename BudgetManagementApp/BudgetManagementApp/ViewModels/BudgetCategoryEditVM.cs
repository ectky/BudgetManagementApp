using BudgetManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BudgetManagementApp.ViewModels
{
    public class BudgetCategoryEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Budget")]
        public int BudgetId { get; set; }
        public IEnumerable<SelectListItem> BudgetsList { get; set; }

    }
}
