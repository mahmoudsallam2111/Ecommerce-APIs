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
        public IEnumerable<ReadproductDto> GetAll()
        {
            var ProductListFromDb = productRepository.GetAll();
            return ProductListFromDb.Select(d => new ReadproductDto
            {
                Name = d.Name,
                Price = d.Price,
                Available = d.Available,
                Rate = d.Rate
            });
        }


        public ReadproductDto AddProduct(WriteProductDto writeProductDto)
        {
            var productToAdd = mapper.Map<Product>(writeProductDto);
            productRepository.Add(productToAdd);
            productRepository.SaveChange();

            return mapper.Map<ReadproductDto>(productToAdd);
        }

        public ReadproductDto RemoveProduct(DeleteProductDto deleteProductDto)
        {
            var productfromDb = productRepository.GetByID(deleteProductDto.ProductId);
            productRepository.Delete(productfromDb);
            productRepository.SaveChange();
            return mapper.Map<ReadproductDto>(productfromDb);
        }

        public ReadproductDto GetProductById (int id)
        {
            var productfronDb = productRepository.GetByID(id);
            return mapper.Map<ReadproductDto>(productfronDb);
        }

        public  ReadproductDto SearchProductByName(string Name)
        {
               var ProductFromDb =  productRepository.SearchProductByName(Name);
            return  mapper.Map<ReadproductDto>(ProductFromDb);
        }

        public  List<ReadproductDto> SearchProductByCategory(int id)
        {
            var ProductListFromDb =  productRepository.SearchProductByCategory(id);

            return  mapper.Map<List<ReadproductDto>>(ProductListFromDb);

        }


        public List<ReadproductDto> FilterProductByPrices(double min , double max)
        {
            var ProductListFromDb = productRepository.FilterProductByPrices(min, max);

            return mapper.Map<List<ReadproductDto>>(ProductListFromDb);
        }

        public List<ReadproductDto> GetProductPaginated(int PageNumber, int PageSize)
        {
           var ProductFromDBPaginated = productRepository.GetProductPaginated(PageNumber, PageSize);

            return mapper.Map<List<ReadproductDto>>(ProductFromDBPaginated);
        }

        public IEnumerable<ReadproductDto> FilterProductByRate(int rate)
        {
            var ProductFromDB = productRepository.FilterProductByRate(rate);
            return mapper.Map<List<ReadproductDto>>(ProductFromDB);
        }

        public IEnumerable<ReadproductDto> FilterProductByAvailability(bool ava)
        {
            var ProductFromDB = productRepository.FilterProductByAvailability(ava);
            return mapper.Map<List<ReadproductDto>>(ProductFromDB);
        }

        
    }
}
