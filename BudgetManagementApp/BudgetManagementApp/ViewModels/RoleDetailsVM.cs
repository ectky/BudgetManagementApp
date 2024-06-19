using BudgetManagement.Data.Entities;

namespace BudgetManagementApp.ViewModels
{
    public class RoleDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public  List<UserDetailsVM> Users { get; set; }
         
    }
}
