using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class RoleDto:BaseModel
    {
        public RoleDto()
        {
            this.Users = new List<UserDto>();
        }

        public string Name { get; set; }
        public  List<UserDto> Users { get; set; }
    }
}
