using AutoMapper;
using Ecommerce.Business.Interfaces;
using Ecommerce.Core.DTos.ProductDTos;
using Ecommerce.Core.Utilities;
using Ecommerce.Data.Interfaces;
using Ecommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Implementaions
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ProductDto>> Add(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            product.IsActive = true;
            var addedCategory = await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductDto>(ResultStatus.Success, $"{productAddDto.Name} adlı kategori başarı ile eklenmiştir.", new ProductDto
            {
                Product = addedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{productAddDto.Name} adlı kategori başarı ile eklenmiştir."
            });
        }

        public async Task<IDataResult<ProductDto>> Delete(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == productId);
            if (product != null)
            {
                product.IsDeleted = false;
                var deletedProduct = await _unitOfWork.Products.UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                return new DataResult<ProductDto>(ResultStatus.Success, $"{deletedProduct.Name} adlı kategori başarı ile silinmiştir.", new ProductDto
                {
                    Product = deletedProduct,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedProduct.Name} adlı kategori başarı ile silinmiştir"

                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, $"Böyle bir kategori bulunamadı", new ProductDto
            {
                Product = null,
                ResultStatus = ResultStatus.Error,
                Message = $"Böyle bir kategori bulunamadı"

            });

        }

        public async Task<IDataResult<ProductDto>> Get(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == productId);
            if (product != null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı", new ProductDto
            {
                Product = null,
                ResultStatus = ResultStatus.Error,
                Message = "Böyle bir kategori bulunamadı"
            });

        }

        public async Task<IDataResult<ProductListDto>> GetAll()
        {
            var product = await _unitOfWork.Products.GetAllAsync(null, c => c.Category);
            if (product.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", new ProductListDto
            {
                Product = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir kategori bulunamadı."
            });
        }

        public async Task<IDataResult<ProductListDto>> GetAllByNonDeleted()
        {
            var product = await _unitOfWork.Products.GetAllAsync(c => c.IsDeleted == true, c => c.Category);
            if (product.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", new ProductListDto
            {
                Product = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir kategori bulunamadı."
            });

        }


        public async Task<IDataResult<ProductDto>> Update(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            var updatedCategory = await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductDto>(ResultStatus.Success, $"{productUpdateDto.Name} adlı kategori başarı ile güncellenmiştir.", new ProductDto
            {
                Product = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{productUpdateDto.Name} adlı kategori başarı ile güncellenmiştir."
            });

        }
    }
}