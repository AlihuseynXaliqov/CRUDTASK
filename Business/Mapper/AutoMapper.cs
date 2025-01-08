using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Business.DTOs.Auth;
using Core.Entities;

namespace Business.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateCategoryDTOs,Category>().ReverseMap();
            CreateMap<GetCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,GetCategoryDto>().ReverseMap();


            CreateMap<AppUser,RegisterDto>().ReverseMap();



        }
    }
}
