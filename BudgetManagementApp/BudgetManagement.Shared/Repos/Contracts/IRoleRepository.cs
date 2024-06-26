﻿using BudgetManagement.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Repos.Contracts
{
    public interface IRoleRepository : IBaseRepository<RoleDto>
    {
        Task<RoleDto> GetByNameIfExistsAsync(string name);
    }
}
