using AutoMapper;
using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Repos
{
    [AutoBind]

    // TO DO:
    public class UserRepository : BaseRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(BudgetManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public Task<bool> CanUserLoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
