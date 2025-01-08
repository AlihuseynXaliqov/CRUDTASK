using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs.Blog;
using Business.Service.Interface;
using DAL.Repo.Abstraction;
using DAL.Repo.Interface;

namespace Business.Service.Implementation
{
    public class BlogService : IBlogService
    {
        IBlogRepository _repo;
        IMapper mapper;

        public BlogService(IBlogRepository repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }

        public List<GetBlogDto> GetAll()
        {
            var blog= _repo.GetAll("User", "BlogsCategories", "BlogsCategories.Category");
           var returnBlog= mapper.Map<List<GetBlogDto>>(blog);
            return returnBlog;
        }
    }
}
