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
    public class BookRepository : BaseRepository<Book, Context.Context>, IBookRepository
    {
        public async Task<Book> GetByIdAsycn(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.BookID == id, includeList);

        }

        public async Task<List<Book>> GetByNameAsycn(string name, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Name == name, includeList);

        }

        public async Task<List<Book>> GetByPriceRangeAsycn(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Price < max && prd.Price > min, includeList);

        }

     
    }
}
