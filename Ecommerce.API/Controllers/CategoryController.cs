using Ecommerce.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminsOnly")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return  Ok( await categoryManager.GetAll());    
        }

        [HttpGet]
        [Route("{id}")]
        public async Task< ActionResult<ReadCategory>> GetById(int id)
        {
               var category =  await categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<ReadCategory>> Add(WriteCategory writeCategory)
        {
            return await categoryManager.AddCategory(writeCategory);
        }

        [HttpDelete]
        public async Task< ActionResult<ReadCategory>> Delete(DeleteCategoryDto deleteCategoryDto)
        {
            return await categoryManager.DeleteCategory(deleteCategoryDto);
        }


    }
}


