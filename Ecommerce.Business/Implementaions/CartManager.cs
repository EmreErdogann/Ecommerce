using AutoMapper;
using Ecommerce.Business.Interfaces;
using Ecommerce.Core.DTos.CartDTos;
using Ecommerce.Core.Utilities;
using Ecommerce.Data.Interfaces;
using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Implementaions
{

    public class CartManager : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public CartManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IDataResult<CartDto>> Add(CartAddDto cartAddDto)
        {
            var cart = _mapper.Map<Cart>(cartAddDto);
            var addedCart = await _unitOfWork.Carts.AddAsync(cart);
            await _unitOfWork.SaveAsync();
            return new DataResult<CartDto>(ResultStatus.Success, $"{cartAddDto.UserId} adlı kategori başarı ile eklenmiştir.", new CartDto
            {
                Cart = addedCart,
                ResultStatus = ResultStatus.Success

            });
        }

        public async Task CartAsync(string userId)
        {
            await _unitOfWork.Carts.Cart(userId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IDataResult<CartDto>> GetByUser(int userId)
        {
            var category = await _unitOfWork.Carts.GetAsync(p => p.UserId == userId.ToString(), p => p.CartItems);
            if (category != null)
            {
                return new DataResult<CartDto>(ResultStatus.Success, new CartDto
                {
                    Cart = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CartDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", new CartDto
            {
                Cart = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kategori bulunamadı"
            });
        }


        public async Task<IDataResult<CartOptionalDto>> GetByUserOptional(int userId)
        {
            var category = await _unitOfWork.Carts.GetAsync(p => p.UserId == userId.ToString(), p => p.CartItems);
            if (category != null)
            {
                return new DataResult<CartOptionalDto>(ResultStatus.Success, new CartOptionalDto
                {
                    UserId=category.Id.ToString(),
                    CartItems=category.CartItems,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CartOptionalDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", new CartOptionalDto
            {
                UserId = null,
                CartItems = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kategori bulunamadı"
            });
        }
    }


}
