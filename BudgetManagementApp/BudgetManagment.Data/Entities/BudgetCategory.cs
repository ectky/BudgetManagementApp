using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class BudgetCategory : BaseEntity
    {
        public BudgetCategory()
        {
            this.Budgets = new List<Budget>();
        }

        public string Name { get; set; }
        public virtual List<Budget> Budgets { get; set; }
    }
}
