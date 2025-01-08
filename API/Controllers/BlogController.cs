using Business.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IBlogService blogService;
        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(blogService.GetAll());
        }


    }
}
