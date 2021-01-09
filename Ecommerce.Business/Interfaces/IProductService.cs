using Ecommerce.Core.DTos.ProductDTos;
using Ecommerce.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Interfaces
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> Get(int productId);
        Task<IDataResult<ProductListDto>> GetAll();
        Task<IDataResult<ProductListDto>> GetAllByNonDeleted();
        Task<IDataResult<ProductDto>> Add(ProductAddDto productAddDto);
        Task<IDataResult<ProductDto>> Update(ProductUpdateDto productUpdateDto);
        Task<IDataResult<ProductDto>> Delete(int productId);
    }
}
