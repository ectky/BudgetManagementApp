using AutoMapper;
using BudgetManagement.Data.Entities;
using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Security;
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
    public class UserRepository : BaseRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(BudgetManagementDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<bool> CanUserLoginAsync(string username, string password)
        {
            var hashedPassword = (await this.GetByUsernameAsync(username))?.Password;
            return PasswordHasher.VerifyPassword(password, hashedPassword);
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            return MapToModel(await _dbSet.FirstOrDefaultAsync(l => l.Username == username));
        }
    }
}
