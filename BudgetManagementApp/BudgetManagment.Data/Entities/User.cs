using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Data.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Budgets = new List<Budget>();
            this.FinanceGoals = new List<FinanceGoal>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Budget> Budgets { get; set; }
        public virtual List<FinanceGoal> FinanceGoals { get; set; }
    }
}
