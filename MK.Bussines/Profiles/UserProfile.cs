using AutoMapper;
using MK.Model.Dtos.Category;
using MK.Model.Dtos.User;
using MK.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.Business.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
        }
    }
}
