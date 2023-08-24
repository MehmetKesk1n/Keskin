using AutoMapper;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using MK.Business.CustomExceptions;
using MK.Business.Interface;
using MK.DataAccess.Interfaces;
using MK.Model.Dtos.Category;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Implementation
{
    public class CategoryBS : ICategoryBs
    {
        public readonly ICategoryRepository _crepo;
        private readonly IMapper _mapper;
        public CategoryBS(ICategoryRepository crepo, IMapper mapper)
        {
            _mapper = mapper;
            _crepo = crepo;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var category = await _crepo.GetByIdAsync(id);
            _crepo.DeleteAsync(category);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIDAsync(int categoryid, params string[] includeList)
        {
            var category = await _crepo.GetByIdAsync(categoryid, includeList);
            if (category != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(category);
                return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Aradığınız Kategori Bulunamadı.");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoryAsync(params string[] includeList)
        {
            var category = await _crepo.GetAllAsync(includeList: includeList);
            if (category.Count > 0)
            {
                var categoryList = _mapper.Map<List<CategoryGetDto>>(category);
                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, categoryList);
            }
            throw new NotFoundException("Kategori Bulunamadı.");
        }


        public async Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            var insertedCategory = await _crepo.InsertAsync(category);
            return ApiResponse<Category>.Success(StatusCodes.Status200OK, insertedCategory);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _crepo.UpdateAsync(category);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
