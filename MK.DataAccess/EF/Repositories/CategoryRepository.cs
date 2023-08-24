using CommonTypesLayer.DataAccess.Implementations.EF;
using MK.DataAccess.Interfaces;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.DataAccess.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, Context.Context>, ICategoryRepository
    {
        public async Task<List<Category>> GetByDescriptionAsync(string description, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int CategoryId, params string[] includeList)
        {
            var result = await GetAsync(cat => cat.CategoryID == CategoryId);
            return result;
        }
    }
}
