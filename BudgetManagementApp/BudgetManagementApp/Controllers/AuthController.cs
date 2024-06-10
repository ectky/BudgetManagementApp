using AutoMapper;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Enums;
using BudgetManagement.Shared.Security;
using BudgetManagement.Shared.Services.Contracts;
using BudgetManagementApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Constants = BudgetManagement.Shared.Constants;

namespace BudgetManagementApp.Controllers
{
    
        [AllowAnonymous]
        public class AuthController : Controller
        {
            private readonly IUserService usersService;
            private readonly IRoleService rolesService;
            private readonly IMapper mapper;
            public AuthController(IUserService usersService,
                IRoleService rolesService,
                    IMapper mapper)
            {
                this.usersService = usersService;
                this.rolesService = rolesService;
                this.mapper = mapper;
            }
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Login([FromForm] LoginVM model)
            {
                string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;
                if (loggedUsername != null)
                {
                    return Forbid();
                }
                if (!await this.usersService.CanUserLoginAsync(model.Username, model.Password))
                {
                    return BadRequest(Constants.InvalidCredentials);
                }
                await LoginUser(model.Username);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            private async Task LoginUser(string username)
            {
                var user = await this.usersService.GetByUsernameAsync(username);
                var claims = new[]
                {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role.Name),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            }
            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Register([FromForm] RegisterVM userCreateModel)
            {
                string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;
                if (loggedUsername != null)
                {
                    return Forbid();
                }
                if (await this.usersService.GetByUsernameAsync(userCreateModel.Username) != default)
                {
                    return BadRequest(Constants.UserAlreadyExists);
                }
                var hashedPassword = PasswordHasher.HashPassword(userCreateModel.Password);
                userCreateModel.Password = hashedPassword;
                var userDto = this.mapper.Map<UserDto>(userCreateModel);
                userDto.RoleId = (await rolesService.GetByNameIfExistsAsync(UserRole.User.ToString())).Id;
                await this.usersService.SaveAsync(userDto);
                await LoginUser(userDto.Username);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            [HttpGet]
            public async Task<IActionResult> Logout()
            {
                string loggedUsername = User.FindFirst(ClaimTypes.Name)?.Value;
                if (loggedUsername != null)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    
}
