using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class BudgetReport : BaseEntity
    {

        public int BudgetId { get; set; }

        public virtual Budget Budget { get; set; }
        
        public int ReportId { get;set; }
        public virtual Report Report { get; set; }  
       
    }
}
