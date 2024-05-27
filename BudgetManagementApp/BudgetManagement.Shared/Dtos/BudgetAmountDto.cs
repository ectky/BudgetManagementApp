using BudgetManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class BudgetAmountDto : BaseModel

    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int BudgetId { get; set; }

        public  BudgetDto Budget { get; set; }

        public BudgetType Type { get; set; }
    }
}
