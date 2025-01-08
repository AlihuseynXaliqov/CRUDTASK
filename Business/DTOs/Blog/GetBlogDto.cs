using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Business.DTOs.Blog
{
    public record GetBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string AuthorId { get; set; }
        public AppUser User { get; set; }
        public ICollection<BlogsCategories> BlogsCategories { get; set; }
    }
}
