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
    public class BudgetReportService : BaseCrudService<BudgetReportDto, IBudgetReportRepository>, IBudgetReportService
    {
        public BudgetReportService(IBudgetReportRepository repository) : base(repository)
        {
            
        }
    }
}
