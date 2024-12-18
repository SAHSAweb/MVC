using AutoMapper;
using MVC.BL.IServices;
using MVC.Interfaces;
using MVC.Model;
using MVC.ViewModels;

namespace MVC.ServicesUI
{
    public class ProductService : IUiService<ProductViewModel>
    {
        private readonly IService<ProductDto> _productService;
        private readonly IMapper _mapper;

        public ProductService(IService<ProductDto> service, IMapper mapper)
        {
            _productService = service;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<List<ProductViewModel>>(_productService.GetAll());
        }

        public void Add(ProductViewModel data)
        {
            _productService.Add(_mapper.Map<ProductDto>(data));
        }

        public void Update(ProductViewModel data)
        {
            var product = _mapper.Map<ProductDto>(data);
            _productService.Update(product);
        }
        public void Delete(Guid id)
        {
            _productService.Delete(id);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productService.GetById(id));
        }
    }

}
