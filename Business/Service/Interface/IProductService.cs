using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;
using Business.DTOs.Product;

namespace Business.Service.Interface
{
    public interface IProductService
    {
        Task<CreateProductDto> CreateAsync(CreateProductDto dto);
        Task<GetProductDto> GetById(int id);

        IQueryable<GetProductDto> GetAll();

        Task Update(UpdateProductDto dto);
        /*
        Task Delete(int id);*/
    }
}
