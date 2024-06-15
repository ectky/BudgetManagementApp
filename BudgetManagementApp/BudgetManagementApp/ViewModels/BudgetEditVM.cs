using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> BudgetCategoriesList { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }
        public IEnumerable<SelectListItem> UsersList { get; set; }

    }
}
