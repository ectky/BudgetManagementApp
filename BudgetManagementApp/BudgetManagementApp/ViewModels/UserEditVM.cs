using BudgetManagement.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagementApp.ViewModels
{
    public class UserEditVM : BaseVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Role")]
        public int RoleId { get; set; }
        [Required]
        public Role Role { get; set; }
        
    }
}
