using AutoMapper;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using BudgetManagementApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace BudgetManagementApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
    public class ReportController : BaseCrudController<ReportDto, IReportRepository, IReportService, ReportEditVM, ReportDetailsVM>
    {
        public ReportController(IReportService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
