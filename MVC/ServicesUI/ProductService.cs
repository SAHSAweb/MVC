using AutoMapper;
using MVC.BL.IServices;
using MVC.Interfaces;
using MVC.Model;
using MVC.Model.Enams;
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

        public IEnumerable<ProductViewModel> GetAll(Products category)
        {
            return _mapper.Map<List<ProductViewModel>>(_productService.GetAll(category));
        }

        public void Add(ProductViewModel data)
        {
            var product = _mapper.Map<ProductDto>(data);
            _productService.Add(product);
        }
        //public void Add(ProductViewModel data)
        //{
        //    // Создаем экземпляр ProductDto
        //    var product = new ProductDto
        //    {
        //        Id = data.Id,                     // Если у вас есть Id в ViewModel
        //        Name = data.Name,                 // Прямое сопоставление свойств
        //        Price = data.Price,               // Если типы совпадают
        //        Quantity = data.Quantity,   // Дополнительные свойства
        //        Category = data.Category      // Или любые другие свойства
        //    };

        //    // Передаем объект в сервис
        //    _productService.Add(product);
        //}


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
