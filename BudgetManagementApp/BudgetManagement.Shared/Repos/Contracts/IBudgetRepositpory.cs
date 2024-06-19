using BudgetManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Repos.Contracts
{
    public interface IBudgetRepository : IBaseRepository<BudgetDto>
    {
        Task AddBudgetToReport(int budgetId, int reportId);
        Task Transfer(int budgetAmountId, int budgetId);
    }
}
