using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Blog;

namespace Business.Service.Interface
{
    public interface IBlogService
    {
        List<GetBlogDto> GetAll();
    }
}
