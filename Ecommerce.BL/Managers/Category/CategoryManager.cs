using AutoMapper;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class CategoryManager:ICategoryManager{
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryManager(ICategoryRepository categoryRepository , IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }



        public List<ReadCategory> GetAll()
        {
            var CategoriesFromDB = categoryRepository.GetAll().ToList();
            return mapper.Map<List<ReadCategory>>(CategoriesFromDB);
        }

        public ReadCategory? GetById(int id)
        {
            var CategoryFromDB = categoryRepository.GetByID(id);
            return mapper.Map<ReadCategory>(CategoryFromDB);
        }


        public ReadCategory AddCategory(WriteCategory writeCategory)
        {
            var categorytoAdd = mapper.Map<Category>(writeCategory);
            categoryRepository.Add(categorytoAdd);
            categoryRepository.SaveChange();
            return mapper.Map<ReadCategory>(categorytoAdd);
        }

        public ReadCategory DeleteCategory(DeleteCategoryDto deleteCategoryDto)
        {
            var categoryFromDb = categoryRepository.GetByID(deleteCategoryDto.Id);
            categoryRepository.Delete(categoryFromDb);
            categoryRepository.SaveChange();
            return mapper.Map<ReadCategory>(categoryFromDb);

        }

        public ReadCategory UpdateCatecory(WriteCategory writeCategory)
        {
            throw new NotImplementedException();
        }
    }
}
