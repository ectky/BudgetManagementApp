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
        // TO DO:
        /*public UserRepository(PetShelterDbContext context, IMapper mapper) : base(context, mapper)
        {
        }*/
    }
}
