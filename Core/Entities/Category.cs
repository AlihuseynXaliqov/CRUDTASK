using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public IQueryable<Product> Products { get; set; }
    }
}
