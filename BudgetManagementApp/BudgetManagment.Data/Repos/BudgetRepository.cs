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
    public class BudgetRepository : BaseRepository<Budget, BudgetDto>, IBudgetRepository
    {
        private readonly IBudgetReportRepository _reportsRepository;
        private readonly IBudgetAmountRepository _budgetAmountRepository;
        public BudgetRepository(BudgetManagementDbContext context, IMapper mapper, IBudgetReportRepository reportsRepository, IBudgetAmountRepository budgetAmountRepository) : base(context, mapper)
        {
            this._reportsRepository = reportsRepository;
            this._budgetAmountRepository = budgetAmountRepository;
        }

        public async Task AddBudgetToReport(int budgetId, int reportId)
        {
            var br = new BudgetReportDto();
            br.BudgetId = budgetId;
            br.ReportId = reportId;
            await _reportsRepository.SaveAsync(br);

        }

        public async Task Transfer(int budgetAmountId, int budgetId)
        {
            
            var budgetAmount = await _budgetAmountRepository.GetByIdAsync(budgetAmountId);
            budgetAmount.BudgetId = budgetId;
            await _budgetAmountRepository.SaveAsync(budgetAmount);
        }
    }
}
