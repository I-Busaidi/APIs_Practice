using API_Practice1.Models;
using API_Practice1.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryByName/{name}")]
        public IActionResult GetCategoryByName(string name)
        {
            try
            {
                var category = _categoryService.GetCategoryByName(name);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCategory(string categoryName)
        {
            try
            {
                _categoryService.AddCategory(new Category
                {
                    CatName = categoryName
                });
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/UpdateCategory")]
        public IActionResult UpdateCategory(int id, string name)
        {
            try
            {
                _categoryService.UpdateCategory(id, new Category
                {
                    CatName=name
                });
                return NoContent();
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.RemoveCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
