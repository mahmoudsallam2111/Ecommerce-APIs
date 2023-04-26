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
        List<ReadCategory> GetAll();
        ReadCategory? GetById(int id);

        ReadCategory AddCategory(WriteCategory writeCategory);

        ReadCategory UpdateCatecory(WriteCategory writeCategory);

        ReadCategory DeleteCategory(DeleteCategoryDto deleteCategoryDto);


    }
}
