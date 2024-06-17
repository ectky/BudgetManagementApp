using AutoMapper;
using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using BudgetManagementApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetManagementApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
    public class FinanceGoalController : BaseCrudController<FinanceGoalDto, IFinanceGoalRepository, IFinanceGoalService, FinanceGoalEditVM, FinanceGoalDetailsVM>
    {
        protected readonly IBudgetService _budgetService;
        protected readonly IUserService _userService;

        public FinanceGoalController(IFinanceGoalService service, IMapper mapper, IBudgetService budgetService, IUserService userService) : base(service, mapper)
        {
            this._budgetService = budgetService;
            this._userService = userService;
        }

        protected override async Task<FinanceGoalEditVM> PrePopulateVMAsync(FinanceGoalEditVM editVM)
        {

            editVM.BudgetsList = (await _budgetService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            editVM.UsersList = (await _userService.GetAllAsync())
            .Select(x => new SelectListItem($"{x.Username}", x.Id.ToString()));

            return editVM;
        }
    }
}
