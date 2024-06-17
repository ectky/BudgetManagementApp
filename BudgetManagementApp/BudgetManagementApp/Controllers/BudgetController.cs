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
    public class BudgetController : BaseCrudController<BudgetDto, IBudgetRepository, IBudgetService, BudgetEditVM, BudgetDetailsVM>
    {

        protected readonly IBudgetCategoryService _budgetCategoryService;
        protected readonly IUserService _userService;
        private readonly IBudgetAmountService _budgetAmountService;

        public BudgetController(IBudgetService service, IMapper mapper, IBudgetCategoryService budgetCategoryService, IUserService userService, IBudgetAmountService budgetAmountService) : base(service, mapper)
        {
            this._budgetCategoryService = budgetCategoryService;
            this._userService = userService;
            this._budgetAmountService = budgetAmountService;

        }

        protected override async Task<BudgetEditVM> PrePopulateVMAsync(BudgetEditVM editVM)
        {

            editVM.BudgetCategoriesList = (await _budgetCategoryService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            editVM.UsersList = (await _userService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Username}", x.Id.ToString()));

            editVM.BudgetAmountsList = (await _budgetAmountService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Amount}", x.Id.ToString()));

            return editVM;
        }
    }
}
