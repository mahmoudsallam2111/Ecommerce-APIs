using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public interface ICategoryManager
    {
      Task<  List<ReadCategory>> GetAll();
      Task<  ReadCategory?> GetById(int id);

      Task<  ReadCategory> AddCategory(WriteCategory writeCategory);

     Task<   ReadCategory > UpdateCatecory(WriteCategory writeCategory);

      Task<ReadCategory> DeleteCategory(DeleteCategoryDto deleteCategoryDto);


    }
}
