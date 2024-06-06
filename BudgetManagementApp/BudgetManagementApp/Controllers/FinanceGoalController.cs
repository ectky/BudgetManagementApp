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
    public class FinanceGoalController : BaseCrudController<FinanceGoalDto, IFinanceGoalRepository, IFinanceGoalService, FinanceGoalEditVM, FinanceGoalDetailsVM>
    {
        public FinanceGoalController(IFinanceGoalService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
