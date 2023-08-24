using CommonTypesLayer.DataAccess.Interfaces;
using CommonTypesLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypesLayer.DataAccess.Implementations.EF
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        //CRUD işlemlerinin nasıl gerçekleşeceğini yazdığım sınıf
        public async Task DeleteAsync(TEntity entitiy)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entitiy);
            await ctx.SaveChangesAsync();
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                        dbSet = dbSet.Include(item);
                }

                return await dbSet.SingleOrDefaultAsync(predicate);
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            //delagate generic
            //func
            //act
            //pridicate
            //Expression<Func<Product>,bool>
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbSet = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                        dbSet = dbSet.Include(item);
                }
                if (predicate == null)
                    return await dbSet.ToListAsync();
                else
                    return await dbSet.Where(predicate).ToListAsync();
            }

        }

        public async Task<TEntity> InsertAsync(TEntity entitiy)
        {
            using var ctx = new TContext();
            var entityT = ctx.Set<TEntity>().AddAsync(entitiy);
            await ctx.SaveChangesAsync();
            return entityT.Result.Entity;
        }

        public async Task UpdateAsync(TEntity entitiy)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Update(entitiy);
            await ctx.SaveChangesAsync();
        }

    }
}
