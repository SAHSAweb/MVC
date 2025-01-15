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

        public IEnumerable<UserViewModel> GetAll(UserTypes user)
        {
           // var users = _userRepository.GetAll(user);
            return _mapper.Map<List<UserViewModel>>(_userRepository.GetAll(user));
        }
        public bool Add(UserViewModel data)
        {
            var user = _mapper.Map<UserDto>(data);
           return _userRepository.Add(user);
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public UserViewModel GetById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public void Update(UserViewModel data)
        {
            throw new NotImplementedException();
        }
    }
}
