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



        public async Task< List<ReadCategory> >GetAll()
        {
            var CategoriesFromDB = await categoryRepository.GetAll();
            return mapper.Map<List<ReadCategory>>(CategoriesFromDB);
        }

        public async Task< ReadCategory? >GetById(int id)
        {
            var CategoryFromDB = await categoryRepository.GetByID(id);
            return mapper.Map<ReadCategory>(CategoryFromDB);
        }


        public async Task< ReadCategory> AddCategory(WriteCategory writeCategory)
        {
            var categorytoAdd = mapper.Map<Category>(writeCategory);
          await  categoryRepository.Add(categorytoAdd);
            categoryRepository.SaveChange();
            return mapper.Map<ReadCategory>(categorytoAdd);
        }

        public async Task< ReadCategory> DeleteCategory(DeleteCategoryDto deleteCategoryDto)
        {
            var categoryFromDb = await categoryRepository.GetByID(deleteCategoryDto.Id);
            categoryRepository.Delete(categoryFromDb);
            categoryRepository.SaveChange();
            return mapper.Map<ReadCategory>(categoryFromDb);

        }

        public Task< ReadCategory> UpdateCatecory(WriteCategory writeCategory)
        {
            throw new NotImplementedException();
        }
    }
}
