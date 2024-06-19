using System.ComponentModel.DataAnnotations;
namespace BudgetManagementApp.ViewModels
{
    public class ReportEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        
    }
}
