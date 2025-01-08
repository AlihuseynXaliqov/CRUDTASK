using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Business.Service.Interface;
using Business.Utils.Exception;
using Core.Entities;
using DAL.Repo.Interface;

namespace Business.Service.Abstraction
{
    internal class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCategoryDTOs> CreateAsync(CreateCategoryDTOs dto)
        {
           
            
            var category = mapper.Map<Category>(dto);
            await categoryRepository.CreateAsync(category);
            await categoryRepository.SaveChangesAsync();
            return mapper.Map<CreateCategoryDTOs>(category);

        }

        public async Task<GetCategoryDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new NegativIdException();
            }
            var dto = await categoryRepository.GetById(id);
            var category = mapper.Map<GetCategoryDto>(dto);

            return category != null ? category : throw new NotFoundException<Category>();
        }

        public IQueryable<GetCategoryDto> GetAll()
        {
            var categories = categoryRepository.GetAll();
            var allCategory = categories.Select(x => mapper.Map<GetCategoryDto>(x));
            return allCategory;
        }

        public async Task Update(UpdateCategoryDto dto)
        {
            var oldCategory=await GetById(dto.Id);
            var category = mapper.Map<GetCategoryDto>(dto);
             categoryRepository.Update(mapper.Map<Category>(category));
            await categoryRepository.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var oldCategory= await GetById(id);
            var category=mapper.Map<Category>(oldCategory);
            categoryRepository.Delete(category);
            await categoryRepository.SaveChangesAsync();

        }
    }
}
