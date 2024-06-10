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
    public class FinanceGoalsService : BaseCrudService<FinanceGoalDto, IFinanceGoalRepository>,IFinanceGoalService
    {
        public FinanceGoalsService(IFinanceGoalRepository repository) : base(repository)
        {
        }
    }
}
