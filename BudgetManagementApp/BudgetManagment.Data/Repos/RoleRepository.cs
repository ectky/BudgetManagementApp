using AutoMapper;
using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Repos
{
    [AutoBind]
    // TO DO:
    public class RoleRepository : BaseRepository<Role, RoleDto>, IRoleRepository
    {
        public RoleRepository(BudgetManagementDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public async Task<RoleDto> GetByNameIfExistsAsync(string name)
        {
            return MapToModel(await _dbSet.FirstOrDefaultAsync(l =>l.Name== name));
        }
    }
}