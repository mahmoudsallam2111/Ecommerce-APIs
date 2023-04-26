using AutoMapper;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.BL
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task< IEnumerable<ReadproductDto>> GetAll()
        {
            var  ProductListFromDb = await productRepository.GetAll();
            return ProductListFromDb.Select(d => new ReadproductDto
            {
                Name = d.Name,
                Price = d.Price,
                Available = d.Available,
                Rate = d.Rate
            });
        }


        public async Task<ReadproductDto> AddProduct(WriteProductDto writeProductDto)
        {
            var productToAdd =  mapper.Map<Product>(writeProductDto);
              await  productRepository.Add(productToAdd);
            productRepository.SaveChange();

            return  mapper.Map<ReadproductDto>(productToAdd);
        }

        public async Task<ReadproductDto> RemoveProduct(DeleteProductDto deleteProductDto)
        {
            var productfromDb = await productRepository.GetByID(deleteProductDto.ProductId);
            productRepository.Delete(productfromDb);
            productRepository.SaveChange();
            return  mapper.Map<ReadproductDto>(productfromDb);
        }

        public async Task<ReadproductDto> GetProductById (int id)
        {
            var productfronDb = await productRepository.GetByID(id);
            return  mapper.Map<ReadproductDto>(productfronDb);
        }

        public  async Task<ReadproductDto> SearchProductByName(string Name)
        {
               var ProductFromDb = await  productRepository.SearchProductByName(Name);
            return  mapper.Map<ReadproductDto>(ProductFromDb);
        }

        public  async Task< List<ReadproductDto> > SearchProductByCategory(int id)
        {
            var ProductListFromDb = await  productRepository.SearchProductByCategory(id);

            return  mapper.Map<List<ReadproductDto>>(ProductListFromDb);

        }


        public  async Task< List<ReadproductDto>> FilterProductByPrices(double min , double max)
        {
            var ProductListFromDb = await productRepository.FilterProductByPrices(min, max);

            return mapper.Map<List<ReadproductDto>>(ProductListFromDb);
        }

        public async Task< List<ReadproductDto>> GetProductPaginated(int PageNumber, int PageSize)
        {
           var ProductFromDBPaginated =await productRepository.GetProductPaginated(PageNumber, PageSize);

            return mapper.Map<List<ReadproductDto>>(ProductFromDBPaginated);
        }

        public async Task< IEnumerable<ReadproductDto> >FilterProductByRate(int rate)
        {
            var ProductFromDB = await productRepository.FilterProductByRate(rate);
            return mapper.Map<List<ReadproductDto>>(ProductFromDB);
        }

        public async Task< IEnumerable<ReadproductDto>> FilterProductByAvailability(bool ava)
        {
            var ProductFromDB = await productRepository.FilterProductByAvailability(ava);
            return mapper.Map<List<ReadproductDto>>(ProductFromDB);
        }

        
    }
}
