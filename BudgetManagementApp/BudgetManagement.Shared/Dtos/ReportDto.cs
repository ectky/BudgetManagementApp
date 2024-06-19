using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class ReportDto :BaseModel
    {
        

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<BudgetReportDto> BudgetReports { get; set; }

    }
}
