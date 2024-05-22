using BudgetManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class BudgetAmount : BaseEntity
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int BudgetId { get; set; }

        public virtual Budget Budget { get; set; }

        public BudgetType Type { get; set; }
    }
}
