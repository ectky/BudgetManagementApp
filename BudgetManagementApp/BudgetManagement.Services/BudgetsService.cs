using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Services
{
    [AutoBind]
    public class BudgetsService : BaseCrudService<BudgetDto, IBudgetRepository>,IBudgetService
    {
        public BudgetsService(IBudgetRepository repository) : base(repository)
        {
        }

        public Task AddBudgetToReport(int budgetId, int reportId)
        {
            return _repository.AddBudgetToReport(budgetId, reportId);
        }

        public Task Transfer(int budgetAmountId, int budgetId)
        {
            return _repository.Transfer(budgetAmountId, budgetId);
        }
    }
}
