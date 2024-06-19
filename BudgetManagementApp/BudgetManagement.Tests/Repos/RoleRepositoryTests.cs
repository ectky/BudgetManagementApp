using BudgetManagement.Data.Entities;
using BudgetManagement.Data.Repos;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Tests.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace udgetManagement.Tests.Repos
{
    public class RoleRepositoryTests :
         BaseRepositoryTests<RoleRepository, Role, RoleDto>
    {
    }
}
