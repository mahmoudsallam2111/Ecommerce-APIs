using AutoMapper;
using Ecommerce.B;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL
{
   public class WishListManager : IWishListManager
    {
        private readonly IwishListRepository wishListRepository;
        private readonly IMapper mapper;

        public WishListManager(IwishListRepository wishListRepository , IMapper mapper)
        {
            this.wishListRepository = wishListRepository;
            this.mapper = mapper;
        }
        public async Task<List<ReadWishlistDto>> GetAll()
        {
            var wishistfromDb = await wishListRepository.GetAll();
            return mapper.Map<List<ReadWishlistDto>>(wishistfromDb);

        }

        public async Task<ReadWishlistDto?> GetById(int id)
        {
            var wishlistfromDb = await wishListRepository.GetByID(id);
            return mapper.Map<ReadWishlistDto>(wishlistfromDb);
        }

        public async Task<ReadwishlistwithItemsDto> getWishListWithItems(int id)
        {
            var wishlistfromDb = await wishListRepository.getWishListWithItems(id);
            return mapper.Map<ReadwishlistwithItemsDto>(wishlistfromDb);
        }
        public async Task<ReadWishlistDto> AddWishList(WriteWishlistDto writeWishlistDto)
        {
            var wishlisttoAdd = mapper.Map<WishList>(writeWishlistDto);
           await wishListRepository.Add(wishlisttoAdd);
            wishListRepository.SaveChange();
            return mapper.Map<ReadWishlistDto>(wishlisttoAdd);
        }

        public Task<ReadWishlistDto> UpdateWishList(WriteWishlistDto writeWishlistDto)
        {
            throw new NotImplementedException();
        }
        public async Task<ReadWishlistDto> DeleteWishList(DeleteWishlistDto deleteWishlistDto)
        {
            var wishlisttodeletefromDb = await wishListRepository.GetByID(deleteWishlistDto.Id);
            wishListRepository.Delete(wishlisttodeletefromDb);
            wishListRepository.SaveChange();
            return mapper.Map<ReadWishlistDto>(wishlisttodeletefromDb) ;

        }

       
    }
}
