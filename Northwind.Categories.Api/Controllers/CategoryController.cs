using Microsoft.AspNetCore.Mvc;
using Northwind.Categories.Application.Contracts;
using Northwind.Categories.Application.Dtos;

namespace Northwind.Categories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var result = this.categoryService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var result = this.categoryService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("SaveCategory")]
        public IActionResult Post(CategoryDtoSave categoryDtoSave)
        {
            var result = this.categoryService.Add(categoryDtoSave);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("UpdateCategory")]
        public IActionResult Put(CategoryDtoUpdate categoryDtoUpdate)
        {
            var result = this.categoryService.Update(categoryDtoUpdate);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpDelete("RemoveCategory")]
        public IActionResult Delete(CategoryDtoRemove categoryDtoRemove)
        {
            var result = this.categoryService.Remove(categoryDtoRemove);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
