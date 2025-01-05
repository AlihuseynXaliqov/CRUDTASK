using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs;

namespace Business.Service.Interface
{
    public interface ICategoryService
    {
        Task<CreateCategoryDTOs> CreateAsync(CreateCategoryDTOs dto);
        Task<GetCategoryDto> GetById(int id);

        IQueryable<GetCategoryDto> GetAll();

        Task Update(UpdateCategoryDto dto);

        Task Delete(int id);
    }
}
