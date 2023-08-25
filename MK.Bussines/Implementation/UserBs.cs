using AutoMapper;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using MK.Business.CustomExceptions;
using MK.Business.Interface;
using MK.DataAccess.Interfaces;
using MK.Model.Dtos.Book;
using MK.Model.Dtos.User;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Implementation
{
    public class UserBs : IUserBs
    {
        private readonly IUserRepository _urepo;
        private readonly IMapper _mapper;

        public UserBs(IUserRepository urepo, IMapper mapper )
        {
            _urepo = urepo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var user = await _urepo.GetByIdAsycn(id);
            _urepo.DeleteAsync(user);
            return ApiResponse<NoData>.Success( StatusCodes.Status200OK );

        }

        public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int userId, params string[] includeList)
        {
            var user = await _urepo.GetByIdAsycn(userId);

            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Kullanıcı Bulunamadı.");
        }

        public async Task<ApiResponse<List<UserGetDto>>> GetUsersAsync(params string[] includeList)
        {
            var user = await _urepo.GetAllAsync(includeList: includeList);
            if (user.Count > 0)
            {
                var userList = _mapper.Map<List<UserGetDto>>(user);
                var response = ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, userList);

                return response;
            }

            throw new NotFoundException("Aradığınız Kullanıcı Bulunamadı.");
        }
        public async Task<ApiResponse<List<UserGetDto>>> GetLoginAsync(UserGetDto getDto)
        {
            var user = await _urepo.GetAllAsync();
            if (user.Count > 0)
            {
                var userList = _mapper.Map<List<UserGetDto>>(user);
                var response = ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, userList);

                return response;
            }

            throw new NotFoundException("Aradığınız Kullanıcı Bulunamadı.");
        }

        public async Task<ApiResponse<User>> InsertAsync(UserPostDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var insertedUser = await _urepo.InsertAsync(user);
            return ApiResponse<User>.Success(StatusCodes.Status200OK, insertedUser);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UserPutDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _urepo.UpdateAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        
    }
}
