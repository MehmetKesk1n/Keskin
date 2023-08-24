using CommonTypesLayer.DataAccess.Interfaces;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.DataAccess.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<List<Book>> GetByNameAsycn(string name, params string[] includeList);
        Task<List<Book>> GetByPriceRangeAsycn(decimal min, decimal max, params string[] includeList);
        Task<Book> GetByIdAsycn(int id, params string[] includeList);
    }
}
