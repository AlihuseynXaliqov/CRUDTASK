using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Business.Service.Abstraction;
using Business.Service.Implementation;
using Business.Service.Interface;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class AddBusinessProgram
    {
        public static void AddProgram(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddControllers()
                .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IBlogService,BlogService>();
        }
    }
}
