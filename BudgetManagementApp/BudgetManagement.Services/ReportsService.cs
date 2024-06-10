﻿using BudgetManagement.Shared.Attributes;
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
    public class ReportsService : BaseCrudService<ReportDto, IReportRepository>,IReportService
    {
        public ReportsService(IReportRepository repository) : base(repository)
        {
        }
    }
}
