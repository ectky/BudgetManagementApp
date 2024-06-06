using AutoMapper;
using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Dtos;
using BudgetManagementApp.ViewModels;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BudgetManagementApp
{
    internal class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Budget, BudgetDto>().ReverseMap();
            CreateMap<BudgetDto, BudgetEditVM>().ReverseMap();
            CreateMap<BudgetDto, BudgetDetailsVM>().ReverseMap();

            CreateMap<BudgetAmount, BudgetAmountDto>().ReverseMap();
            CreateMap<BudgetAmountDto, BudgetAmountEditVM>().ReverseMap();
            CreateMap<BudgetAmountDto, BudgetAmountDetailsVM>().ReverseMap();

            CreateMap<BudgetCategory, BudgetCategoryDto>().ReverseMap();
            CreateMap<BudgetCategoryDto, BudgetCategoryEditVM>().ReverseMap();
            CreateMap<BudgetCategoryDto, BudgetCategoryDetailsVM>().ReverseMap();

            CreateMap<FinanceGoal, FinanceGoalDto>().ReverseMap();
            CreateMap<FinanceGoalDto, FinanceGoalEditVM>().ReverseMap();
            CreateMap<FinanceGoalDto, FinanceGoalDetailsVM>().ReverseMap();

            CreateMap<Report, ReportDto>().ReverseMap();
            CreateMap<ReportDto, ReportEditVM>().ReverseMap();
            CreateMap<ReportDto, ReportDetailsVM>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleDto, RoleEditVM>().ReverseMap();
            CreateMap<RoleDto, RoleDetailsVM>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserEditVM>().ReverseMap();
            CreateMap<UserDto, UserDetailsVM>().ReverseMap();
        }
    }
}
