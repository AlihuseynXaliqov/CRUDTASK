using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Business.DTOs.Product;
using Business.Service.Interface;
using Core.Entities;
using DAL.Repo.Interface;

namespace Business.Service.Abstraction
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CreateProductDto> CreateAsync(CreateProductDto dto)
        {
            if (!await repository.IsExist(x => x.CategoryId == dto.CategoryId))
            {
                throw new Exception("bele kategoriya movcud deyil");
            }
            var product = mapper.Map<Product>(dto);

            var newProduct = await repository.CreateAsync(product);
            await repository.SaveChangesAsync();
            return mapper.Map<CreateProductDto>(newProduct);
        }

        public IQueryable<GetProductDto> GetAll()
        {
            var products = repository.GetAll();
            var product =products.Select(x => mapper.Map<GetProductDto>(x));
            return product;
        }

        public async Task<GetProductDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("id menfi ve 0 ola bilmez");
            }
            var product = await repository.GetById(id);
            var newProduct= mapper.Map<GetProductDto>(product);
            return newProduct != null ? newProduct : throw new Exception("bele product yoxdu");

        }

        public async Task Update(UpdateProductDto dto)
        {
            if (!await repository.IsExist(x => x.CategoryId == dto.CategoryId))
            {
                throw new Exception("bele kategoriya movcud deyil");
            }
            var oldProduct =await GetById(dto.Id);
            var product= mapper.Map<GetProductDto>(dto);
            repository.Update(mapper.Map<Product>(product));
            await repository.SaveChangesAsync();

        }



        /*        public Task Delete(int id)
                {
                    throw new NotImplementedException();
                }

                public IQueryable<GetCategoryDto> GetAll()
                {
                    throw new NotImplementedException();
                }

                public Task<GetCategoryDto> GetById(int id)
                {
                    throw new NotImplementedException();
                }

                public Task Update(UpdateCategoryDto dto)
                {
                    throw new NotImplementedException();
                }*/
    }
}
