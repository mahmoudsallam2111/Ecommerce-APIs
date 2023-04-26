using AutoMapper;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<WriteProductDto, Product>();
            CreateMap<Product , ReadproductDto>().ReverseMap();
            CreateMap<Order, ReadorderDto>().ReverseMap();
            CreateMap<Category, ReadCategory>().ReverseMap();
            CreateMap<Category, WriteCategory>().ReverseMap();
            
        }
    }
}
