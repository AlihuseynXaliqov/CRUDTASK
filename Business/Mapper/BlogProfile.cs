using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Blog;
using Core.Entities;

namespace Business.Mapper
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<GetBlogDto,Blog>().ReverseMap();
        }
    }
}
