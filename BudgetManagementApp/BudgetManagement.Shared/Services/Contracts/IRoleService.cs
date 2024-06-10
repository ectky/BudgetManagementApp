using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Services.Contracts
{
    public interface IRoleService : IBaseCrudService<RoleDto, IRoleRepository>
    {
        Task<RoleDto> GetByNameIfExistsAsync(string name);
    }
}
