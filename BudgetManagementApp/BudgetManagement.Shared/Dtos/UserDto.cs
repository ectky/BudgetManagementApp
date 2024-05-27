using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class UserDto:BaseModel
    {
        public UserDto()
        {
            this.Budgets = new List<BudgetDto>();
            this.FinanceGoals = new List<FinanceGoalDto>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public  RoleDto Role { get; set; }
        public  List<BudgetDto> Budgets { get; set; }
        public  List<FinanceGoalDto> FinanceGoals { get; set; }
    }
}
