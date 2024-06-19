using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagementApp.ViewModels
{
    public class BudgetReportEditVM : BaseVM
    {
        [Required]
        [DisplayName("Report")]
        public int ReportId { get; set; }
        public IEnumerable<SelectListItem> ReportsList { get; set; }
        [Required]
        [DisplayName("Budget")]
        public int BudgetId { get; set; }
        public IEnumerable<SelectListItem> BudgetsList { get; set; }
    }
}
