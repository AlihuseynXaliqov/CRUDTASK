using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double oldPrice { get; set; }
        public double newPrice { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }

}
