using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class Report : BaseEntity
    {
        

        public string Name { get; set; }

        public string Description { get; set; }

       
        public virtual List<BudgetReport> BudgetReports { get; set; }
    }
}
