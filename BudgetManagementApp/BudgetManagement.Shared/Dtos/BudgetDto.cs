using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class BudgetDto : BaseModel
    {
        public string Name { get; set; }

        public int BudgetCategoryId { get; set; }

        public  BudgetCategoryDto BudgetCategory { get; set; }

        public  List<BudgetAmountDto> BudgetAmount { get; set; }

        public int UserId { get; set; }

        public  UserDto User { get; set; }
    }
}
