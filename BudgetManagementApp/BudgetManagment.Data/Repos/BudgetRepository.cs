using AutoMapper;
using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Repos
{
    [AutoBind]
    // TO DO:
    public class BudgetRepository : BaseRepository<Budget, BudgetDto>, IBudgetRepository
    {
        private readonly IBudgetReportRepository _reportsRepository;
        public BudgetRepository(BudgetManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AddBudgetToReport(int budgetId, int reportId)
        {
            var br = new BudgetReportDto();
            br.BudgetId = budgetId;
            br.ReportId = reportId;
            await _reportsRepository.SaveAsync(br);

        }
    }
}
