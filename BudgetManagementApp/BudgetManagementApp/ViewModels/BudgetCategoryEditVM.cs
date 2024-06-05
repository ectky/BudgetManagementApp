using BudgetManagement.Data.Entities;
using System.ComponentModel.DataAnnotations;
namespace BudgetManagementApp.ViewModels
{
    public class BudgetCategoryEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        
    }
}
