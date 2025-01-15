using AutoMapper;
using MVC.Model;
using MVC.ViewModels;

namespace MVC
{
    public class MapperUI : Profile
    {
        public MapperUI()
        {
            // Настройка маппинга между ProductViewModel и ProductDto
            CreateMap<ProductViewModel, ProductDto>();

            // Если требуется обратный маппинг (из ProductDto в ProductViewModel):
            CreateMap<ProductDto, ProductViewModel>();

            CreateMap<UserViewModel, UserDto>();
            CreateMap<UserDto, UserViewModel>();

        }
    }
}
