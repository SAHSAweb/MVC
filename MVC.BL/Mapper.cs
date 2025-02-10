
using AutoMapper;
using MVC.DAL.Entities;
using MVC.Model;


namespace MVC.BL
{
    public class MapperBL : Profile
    {
        public MapperBL()
        {
            // Настройка маппинга между ProductViewModel и ProductDto
            CreateMap<Product, ProductDto>();

            // Если требуется обратный маппинг (из ProductDto в ProductViewModel):
            CreateMap<ProductDto, Product>();  


            CreateMap<UserDto, User>();  
            CreateMap<User, UserDto>();

            CreateMap<OrderDto, Order>();  
            CreateMap<Order, OrderDto>();
            
        }
    }

}
