﻿

using MVC.DAL.Entities.Interfaces;
using MVC.DAL.Entities;
using MVC.Model;
using AutoMapper;
using MVC.Model.Enams;
using MVC.BL.Interfaces;

namespace MVC.BL.Services
{
    public class ProductService : IService<ProductDto>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository ;
            _mapper = mapper ;
        }

        public IEnumerable<ProductDto> GetAll(Products category)
        {
            var products = _productRepository.GetAll(category);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public void Add(ProductDto data)
        {
            var product = _mapper.Map<Product>(data);
            _productRepository.Add(product);
        }

        public void Update(ProductDto data)
        {
            var product = _mapper.Map<Product>(data);
            _productRepository.Update(product);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }

        public ProductDto GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

    }
}
