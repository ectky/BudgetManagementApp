using BudgetManagement.Shared.Attributes;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Services
{
    [AutoBind]
    public class UsersService : BaseCrudService<UserDto, IUserRepository>
    {
        public UsersService(IUserRepository repository) : base(repository)
        {
        }
        public Task<bool> CanUserLoginAsync(string username, string password)
        {
            return _repository.CanUserLoginAsync(username, password);
        }
        public Task GetByUsernameAsync(string username)
        {
            return _repository.GetByUsernameAsync(username);
        }
    }
}
