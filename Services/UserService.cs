using AutoMapper;
using BarCLoudTaskBackEnd.DataAccess;
using BarCLoudTaskBackEnd.DTOs.User;
using BarCLoudTaskBackEnd.Entities;
using BarCLoudTaskBackEnd.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarCLoudTaskBackEnd.Services
{
    public class UserService
    {
        private IBarCloudRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IBarCloudRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();


            return _mapper.Map<List<BarCloudUserEntity>, List<UserDTO>> (users);
        }

        public async Task<int> InsertUsers(NewUserDTO user)
        {
            var userEntity = _mapper.Map<NewUserDTO, BarCloudUserEntity>(user);
            return await _userRepository.InsertUserAsync(userEntity);

        }

        public async Task<int> UpdateUser(UserDTO user)
        {
            var userEntity = _mapper.Map<UserDTO, BarCloudUserEntity>(user);
             return await _userRepository.UpdateUserAsync(userEntity);

        }

        public async Task DeleteUser (int userId)
        {

            _=  _userRepository.DeleteUsersAsync(userId);

        }
 

    }
}
