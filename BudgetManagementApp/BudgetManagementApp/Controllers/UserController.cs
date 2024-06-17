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
    public class UserController : BaseCrudController<UserDto, IUserRepository, IUserService, UserEditVM, UserDetailsVM>
    {
        protected readonly IBudgetService _budgetService;
        protected readonly IRoleService _roleService;
        public UserController(IUserService service, IMapper mapper, IBudgetService budgetService, IRoleService roleService) : base(service, mapper)
        {
            this._budgetService = budgetService;
            this._roleService = roleService;
        }
        protected override async Task<UserEditVM> PrePopulateVMAsync(UserEditVM editVM)
        {
            editVM.BudgetsList = (await _budgetService.GetAllAsync())
               .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            editVM.RolesList = (await _roleService.GetAllAsync())
            .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));

            return editVM;
        }
    }
}
