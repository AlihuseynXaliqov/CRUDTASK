using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repo.Abstraction;
using DAL.Repo.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DalProgram
    {
        public static void AddDALProgram(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
        }
    }
}
