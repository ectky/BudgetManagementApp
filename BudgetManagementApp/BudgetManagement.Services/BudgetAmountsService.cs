using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Services
{
    [AutoBind]
    public class BudgetAmountsService : BaseCrudService<BudgetAmountDto, IBudgetAmountRepository>
    {
        public BudgetAmountsService(IBudgetAmountRepository repository) : base(repository)
        {
        }
    }
}
