using AutoMapper;
using Ecommerce.B;
using Ecommerce.BL.Dtos.WishItem;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
    public class WishItemManager : IWshItemManager
    {
        private readonly IWishItemRepository wishItemRepository;
        private readonly IMapper mapper;

        public WishItemManager(IWishItemRepository wishItemRepository , IMapper mapper)
        {
            this.wishItemRepository = wishItemRepository;
            this.mapper = mapper;
        }
        public async Task<ReadWishItemDto> AddWishItem(WriteWishItemDto writeWishItemDto)
        {
           var wishItemToAdd = mapper.Map<WishItem>(writeWishItemDto);
           await wishItemRepository.Add(wishItemToAdd);
            wishItemRepository.SaveChange();
            return mapper.Map<ReadWishItemDto>(wishItemToAdd);  
        }

        public async Task<ReadWishItemDto> deleteWishItem(DeleteWishItemDto deleteWishItemDto)
        {
            var itemtoDeletefromDb = await wishItemRepository.GetByID(deleteWishItemDto.Id);
             wishItemRepository.Delete(itemtoDeletefromDb);
            wishItemRepository.SaveChange();
            return mapper.Map<ReadWishItemDto>(itemtoDeletefromDb) ;
        }

        public async Task<List<ReadWishItemDto>> GetAll()
        {
            var listfromdb = await wishItemRepository.GetAll();
            return mapper.Map<List<ReadWishItemDto>>(listfromdb);
        }

        public async Task<ReadWishItemDto?> GetById(int id)
        {
            var itemfromDb = await wishItemRepository.GetByID(id);
            return mapper.Map<ReadWishItemDto>(itemfromDb);
        }

        public Task<ReadWishItemDto> UpdateWishItem(WriteWishItemDto writeWishItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
