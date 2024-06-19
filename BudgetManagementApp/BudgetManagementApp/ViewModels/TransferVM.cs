using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetManagementApp.ViewModels
{
    public class TransferVM
    {
        public int BudgetId { get; set; }

        public int BudgetAmountId { get; set; }

        public IEnumerable<SelectListItem> Budgets { get; set; }
    }
}
