using BudgetManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagementApp.ViewModels
{
    public class RoleEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }

    }
}
