using CommonTypesLayer.DataAccess.Interfaces;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.DataAccess.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetByDescriptionAsync(string description, params string[] includeList);
        Task<Category> GetByIdAsync(int CategoryId, params string[] includeList);
    }
}
