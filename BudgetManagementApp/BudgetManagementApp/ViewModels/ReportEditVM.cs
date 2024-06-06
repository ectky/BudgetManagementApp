namespace BudgetManagementApp.ViewModels
    using System.ComponentModel.DataAnnotations;
{
    public class ReportEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

       
    }
}
