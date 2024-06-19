using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Enums;
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
    public class FinanceGoalsService : BaseCrudService<FinanceGoalDto, IFinanceGoalRepository>, IFinanceGoalService
    {
        public FinanceGoalsService(IFinanceGoalRepository repository) : base(repository)
        {
        }

        public override async Task<FinanceGoalDto> GetByIdIfExistsAsync(int id)
        {
            var financeGoal = await base.GetByIdIfExistsAsync(id);
            var total = CalculateCompletionPercentage(financeGoal);
            financeGoal.CompletionPercentage = $"{total}%";

            return financeGoal;
        }

        private decimal CalculateCompletionPercentage(FinanceGoalDto financeGoal)
        {
            var incomes = financeGoal.Budget.BudgetAmounts.Where(x => x.Type == BudgetType.Income).Sum(x => x.Amount);
            var expenses = financeGoal.Budget.BudgetAmounts.Where(x => x.Type == BudgetType.Expense).Sum(x => x.Amount);
            var amount = financeGoal.Amount;
            var total = Math.Round(((amount - (amount - (incomes - expenses))) / amount) * 100);
            return total;
        }
    }
}
