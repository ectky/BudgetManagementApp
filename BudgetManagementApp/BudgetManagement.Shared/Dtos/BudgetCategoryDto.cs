using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class BudgetCategoryDto :BaseModel
    {
        public BudgetCategoryDto()
        {
            this.Budgets = new List<BudgetDto>();
        }

        public string Name { get; set; }
        public List<BudgetDto> Budgets { get; set; }
    }
}
