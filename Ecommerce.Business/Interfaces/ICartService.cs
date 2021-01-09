using Ecommerce.Core.DTos.CartDTos;
using Ecommerce.Core.Utilities;
using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Interfaces
{
    public interface ICartService
    {
        Task CartAsync(string userId);
        Task<IDataResult<CartDto>> Add(CartAddDto cartAddDto);
        Task<IDataResult<CartDto>> GetByUser(int userId);
        Task<IDataResult<CartOptionalDto>> GetByUserOptional(int userId);


    }
}
