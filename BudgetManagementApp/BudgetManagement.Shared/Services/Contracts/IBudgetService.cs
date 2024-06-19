using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Services.Contracts
{
    public interface IBudgetService : IBaseCrudService<BudgetDto, IBudgetRepository>
    {
        Task AddBudgetToReport(int budgetId, int reportId);
        Task Transfer(int budgetAmountId, int budgetId);
    }
}
