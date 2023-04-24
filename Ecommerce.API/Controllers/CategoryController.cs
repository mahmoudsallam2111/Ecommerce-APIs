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
        public ActionResult GetAll()
        {
            return Ok(categoryManager.GetAll());    
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadCategory> GetById(int id)
        {
               var category =  categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<ReadCategory> Add(WriteCategory writeCategory)
        {
            return categoryManager.AddCategory(writeCategory);
        }

        [HttpDelete]
        public ActionResult<ReadCategory> Delete(DeleteCategoryDto deleteCategoryDto)
        {
            return categoryManager.DeleteCategory(deleteCategoryDto);
        }


    }
}


