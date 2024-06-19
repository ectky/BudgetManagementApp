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
    public class BudgetReportRepository : BaseRepository<BudgetCategory, BudgetReportDto>, IBudgetReportRepository
    {
        public BudgetReportRepository(BudgetManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
