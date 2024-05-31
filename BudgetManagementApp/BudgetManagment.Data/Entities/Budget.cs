using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class Budget : BaseEntity
    {
        public string Name { get; set; }

        public int BudgetCategoryId { get; set; }

        public virtual BudgetCategory BudgetCategories { get; set; }

        public virtual List<BudgetAmount> BudgetAmounts { get; set; }
        public virtual List<FinanceGoal> FinanceGoals { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
