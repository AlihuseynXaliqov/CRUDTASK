using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Blog: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string AuthorId { get; set; }
        public AppUser User { get; set; }
        public ICollection<BlogsCategories> BlogsCategories { get; set; }

    }
}
