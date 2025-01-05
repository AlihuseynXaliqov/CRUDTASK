using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Business.DTOs.Auth;
using Business.DTOs.Product;
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

            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<GetProductDto,UpdateProductDto>().ReverseMap();

            CreateMap<AppUser,RegisterDto>().ReverseMap();



        }
    }
}
