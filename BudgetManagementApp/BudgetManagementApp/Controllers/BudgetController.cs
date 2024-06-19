using AutoMapper;
using BudgetManagement.Services;
using BudgetManagement.Shared;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using BudgetManagementApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;

namespace BudgetManagementApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin, Employee, User")]
    public class BudgetController : BaseCrudController<BudgetDto, IBudgetRepository, IBudgetService, BudgetEditVM, BudgetDetailsVM>
    {
        protected readonly IReportService _reportService;
        protected readonly IBudgetCategoryService _budgetCategoryService;
        protected readonly IUserService _userService;
        protected readonly IBudgetAmountService _budgetAmountService;

        public BudgetController(IBudgetService service, IMapper mapper, IBudgetCategoryService budgetCategoryService, IReportService reportService, IUserService userService, IBudgetAmountService budgetAmountService) : base(service, mapper)
        {
            this._budgetCategoryService = budgetCategoryService;
            this._userService = userService;
            this._budgetAmountService = budgetAmountService;
            this._reportService = reportService;
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

        [HttpGet]
        public virtual async Task<IActionResult> AddBudgetToReport(int? Id)
        {
            if (Id == null)
            {
                return BadRequest(Constants.InvalidId);
            }

            var model = await this._service.GetByIdIfExistsAsync(Id.Value);

            if (model == default)
            {
                return BadRequest(Constants.InvalidId);
            }

            var addBudgetToReport = new AddBudgetToReportVM();
            addBudgetToReport.BudgetId = Id.Value;
            addBudgetToReport.ReportList = (await _reportService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));
            return View(addBudgetToReport);
        }

        [HttpPost]
        public virtual async Task<IActionResult> AddBudgetToReport(int id, AddBudgetToReportVM editVM)
        {
            await this._service.AddBudgetToReport(editVM.BudgetId, editVM.ReportId);
            return await List();
        }

        [HttpGet]
        public virtual async Task<IActionResult> Transfer(int? Id)
        {
            if (Id == null)
            {
                return BadRequest(Constants.InvalidId);
            }

            var model = await this._budgetAmountService.GetByIdIfExistsAsync(Id.Value);

            if (model == default)
            {
                return BadRequest(Constants.InvalidId);
            }

            var transferVM = new TransferVM();
            transferVM.BudgetAmountId = Id.Value;
            transferVM.Budgets = (await _service.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));
            return View(transferVM);
        }
    }
}
