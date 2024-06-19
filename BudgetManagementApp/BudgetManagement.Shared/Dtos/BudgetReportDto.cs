using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Dtos
{
    public class BudgetReportDto : BaseModel
    {
        public int BudgetId { get; set; }

        public BudgetDto Budget { get; set; }

        public int ReportId { get; set; }

        public ReportDto Report { get; set; }
    }
}
