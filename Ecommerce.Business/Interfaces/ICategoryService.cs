using Ecommerce.Core.DTos.CategoryDTos;
using Ecommerce.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int CategoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleted();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto);
        Task<IDataResult<CategoryDto>> Delete(int CategoryId);
    }
}
