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
    public class BudgetCategoryController : BaseCrudController<BudgetCategoryDto, IBudgetCategoryRepository, IBudgetCategoryService, BudgetCategoryEditVM, BudgetCategoryDetailsVM>
    {
        private readonly IBudgetService _budgetService;
        public BudgetCategoryController(IBudgetCategoryService service, IMapper mapper, IBudgetService budgetService) : base(service, mapper)
        {
            _budgetService = budgetService;
        }

        protected override async Task<BudgetCategoryEditVM> PrePopulateVMAsync(BudgetCategoryEditVM editVM)
        {
            editVM.BudgetsList = (await _budgetService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            return editVM;
        }
    }
}
