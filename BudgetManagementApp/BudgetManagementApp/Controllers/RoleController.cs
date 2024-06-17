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
    public class RoleController : BaseCrudController<RoleDto, IRoleRepository, IRoleService, RoleEditVM, RoleDetailsVM>
    {
        public RoleController(IRoleService service, IMapper mapper, IBudgetService budgetService, IRoleService roleService) : base(service, mapper)
        {
            
        }

    }
}
