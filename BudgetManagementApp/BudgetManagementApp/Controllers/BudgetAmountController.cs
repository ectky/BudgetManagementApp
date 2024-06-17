using AutoMapper;
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
    public class BudgetAmountController : BaseCrudController<BudgetAmountDto, IBudgetAmountRepository, IBudgetAmountService, BudgetAmountEditVM, BudgetAmountDetailsVM>
    {
        private readonly IBudgetService _budgetService;
        public BudgetAmountController(IBudgetAmountService service, IMapper mapper, IBudgetService budgetService) : base(service, mapper)
        {
            _budgetService = budgetService;
        }

        protected override async Task<BudgetAmountEditVM> PrePopulateVMAsync(BudgetAmountEditVM editVM)
        {
            editVM.BudgetsList = (await _budgetService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            return editVM;
        }
    }
}
