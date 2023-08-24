using CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypesLayer.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        //CRUD
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task<TEntity> InsertAsync(TEntity entitiy);
        Task UpdateAsync(TEntity entitiy);
        Task DeleteAsync(TEntity entitiy);

    }
}
