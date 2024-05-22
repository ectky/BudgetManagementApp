using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class FinanceGoal : BaseEntity
    {
        public int BudgetId { get; set; }

        public virtual Budget Budget { get; set; }

        public decimal Amount { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
