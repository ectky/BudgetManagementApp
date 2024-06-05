﻿using BudgetManagement.Shared.Dtos;
using BudgetManagement.Shared.Repos.Contracts;
using BudgetManagement.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Services
{
    public abstract class BaseCrudService<TModel, TRepository> : IBaseCrudService<TModel, TRepository>
        where TModel : BaseModel
        where TRepository : IBaseRepository<TModel>
    {
        protected readonly TRepository _repository;

        protected BaseCrudService(TRepository repository)
        {
            this._repository = repository;
        }

        public virtual async Task SaveAsync(TModel model)
        {
            if (Equals(model, null))
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repository.SaveAsync(model);
        }

        public virtual Task DeleteAsync(int id)
            => this._repository.DeleteAsync(id);

        public virtual Task<TModel> GetByIdIfExistsAsync(int id)
            => this._repository.GetByIdAsync(id);

        public virtual Task<IEnumerable<TModel>> GetWithPaginationAsync(int pageSize, int pageNumber)
            => this._repository.GetWithPaginationAsync(pageSize, pageNumber);

        public virtual Task<IEnumerable<TModel>> GetAllAsync()
            => this._repository.GetAllAsync();

        public Task<bool> ExistsByIdAsync(int id)
            => this._repository.ExistsByIdAsync(id);
    }
}
