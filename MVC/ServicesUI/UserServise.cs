using AutoMapper;
using MVC.Model;
using MVC.Interfaces;
using MVC.ViewModels;
using MVC.BL.Interfaces;
using MVC.Model.Enams;

namespace MVC.ServicesUI
{
    public class UserService : IUsersServiseUI<UserViewModel, UserTypes>
    {
        private readonly IUserService<UserDto> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserService<UserDto> repository, IMapper mapper)
        {
            _userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(UserTypes user)
        {
           // var users = _userRepository.GetAll(user);
            return _mapper.Map<List<UserViewModel>>(await _userRepository.GetAllAsync(user));
        }
        public async Task<bool> AddAsync(UserViewModel data)
        {
            var user = _mapper.Map<UserDto>(data);
           return await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task UpdateAsync(UserViewModel data)
        {
            throw new NotImplementedException();
        }
    }
}
