using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Shared.Services.Contracts
{
    public interface IBaseCrudService<TModel, TRepository>
        where TModel : BaseModel
        where TRepository : IBaseRepository<TModel>
    {
        Task<TModel> GetByIdIfExistsAsync(int id);

        Task SaveAsync(TModel model);

        Task DeleteAsync(int id);

        Task<IEnumerable<TModel>> GetWithPaginationAsync(int pageSize, int pageNumber);

        Task<IEnumerable<TModel>> GetAllAsync();

        Task<bool> ExistsByIdAsync(int id);
    }
}
