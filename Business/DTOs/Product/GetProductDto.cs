using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Product
{
    public class GetProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double oldPrice { get; set; }
        public double newPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
