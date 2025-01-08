using Business.DTOs;
using Business.Service.Interface;
using Business.Utils.Exception;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTOs dto)
        {

                return Ok(await categoryService.CreateAsync(dto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
          
                return Ok(await categoryService.GetById(id));
            
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryDto dto)
        {
         

                await categoryService.Update(dto);
                return Ok();
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.Delete(id);
            return Ok();
        }

    }
}
