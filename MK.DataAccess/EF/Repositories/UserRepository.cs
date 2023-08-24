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
    public class UserRepository : BaseRepository<User, Context.Context>, IUserRepository
    {

        public async Task<User> GetByIdAsycn(int id, params string[] includeList)
        {
            return await GetAsync(usr => usr.UserID == id,includeList);
        }

        public async Task<List<User>> GetByUserNameAsycn(string name, params string[] includeList)
        {
            return await GetAllAsync(usr => usr.UserName == name,includeList);
        }
    }
}
