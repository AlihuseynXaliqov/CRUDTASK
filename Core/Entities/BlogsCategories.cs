using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities
{
    public class BlogsCategories : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blog { get; set; }

    }
}
