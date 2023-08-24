using CommonTypesLayer.DataAccess.Interfaces;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.DataAccess.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<List<User>> GetByUserNameAsycn(string name, params string[] includeList);
        Task<User> GetByIdAsycn(int id, params string[] includeList);
    }
}
