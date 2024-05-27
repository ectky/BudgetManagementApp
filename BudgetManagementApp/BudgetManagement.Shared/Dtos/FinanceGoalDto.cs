using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class FinanceGoalDto :BaseModel
    {
        public int BudgetId { get; set; }

        public  BudgetDto Budget { get; set; }

        public decimal Amount { get; set; }

        public int UserId { get; set; }

        public  UserDto User { get; set; }
    }
}
