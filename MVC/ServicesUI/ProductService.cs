using AutoMapper;
using MVC.BL.Interfaces;
using MVC.Interfaces;
using MVC.Model;
using MVC.Model.Enams;
using MVC.ViewModels;

namespace MVC.ServicesUI
{
    public class ProductService : IProductsServisUI<ProductViewModel, Products>
    {
        private readonly IService<ProductDto> _productService;
        private readonly IMapper _mapper;

        public ProductService(IService<ProductDto> service, IMapper mapper)
        {
            _productService = service;
            _mapper = mapper;
        }
      
        public async Task<IEnumerable<ProductViewModel>> GetAllAsync(Products category)
        {           
            return _mapper.Map<List<ProductViewModel>>(await _productService.GetAllAsync(category));
        }

        public async Task AddAsync(ProductViewModel data)
        {
            var product = _mapper.Map<ProductDto>(data);
            await _productService.AddAsync(product);
        }   

        public async Task UpdateAsync(ProductViewModel data)
        {
            var product = _mapper.Map<ProductDto>(data);
            await _productService.UpdateAsync(product);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _productService.DeleteAsync(id);
        }

        public async Task<ProductViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productService.GetByIdAsync(id));
        }
        public async Task UpdeteProductQuantityAsync(Guid productId, int amount)
        {
            await _productService.UpdeteProductQuantityAsync(productId, amount);
        }
    }

}
