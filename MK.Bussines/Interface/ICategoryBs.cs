using CommonTypesLayer.Utilities;
using MK.Model.Dtos.Category;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Interface
{
    public interface ICategoryBs
    {

        Task<ApiResponse<List<CategoryGetDto>>> GetCategoryAsync(params string[] includeList);
        Task<ApiResponse<CategoryGetDto>> GetByIDAsync(int categoryid, params string[] includeList);
        Task<ApiResponse<Category>> InsertAsync(CategoryPostDto category);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto category);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
