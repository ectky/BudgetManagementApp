using BudgetManagement.Services;
using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;


namespace BudgetManagement.Test.Service
{
    public abstract class BaseServiceTests<TModel, TRepository, TService> 
where TModel : BaseModel
where TRepository : IBaseRepository<TModel>
        where TService : BaseCrudService<TModel, TRepository>
    {
        protected readonly TRepository _repository;
        protected BaseServiceTests(TRepository repository)
        {
            this._repository = repository;
        }

    }
}

