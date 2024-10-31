using ApplicationLayer.DTOs;
using ApplicationLayer.Service.Contract;
using DomainLayer.Entities;
using DomainLayer.Interfaces;
using InfrastructureLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApplicationLayer.Service.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }

        public async Task CreateUserAsync(UserDto user)
        {
            var userE = new User(
       user.Id,
       user.Username,
       user.Password,
       user.Email,
       user.Phone,
       user.Address
   );

            await _unitOfWork.Users.CreateAsync(userE);
            await _unitOfWork.CompleteAsync();



        }

        public async Task DeleteUserAsync(object id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

        }

        public async Task<UserDto> GetUserByIdAsync(object id)
        {
            var UserE = await _unitOfWork.Users.GetByIdAsync(id);
            if (UserE == null) return null; 

            var user = new UserDto(
                UserE.Id,
                UserE.Username,
                UserE.Password,
                UserE.Email,
                UserE.Phone,
                UserE.Address
            );

            return user;
        }


        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.Users.GetAllAsync();


            var userDtos = users.Select(user => new UserDto(
                user.Id,
                user.Username,
                user.Password,
                user.Email,
                user.Phone,
                user.Address
            ));

            return userDtos;
        }


        public async Task UpdateUserAsync(UserDto user)
        {
            var userE = new User(
        user.Id,
        user.Username,
        user.Password,
        user.Email,
        user.Phone,
        user.Address
    );

            await _unitOfWork.Users.UpdateAsync(userE);
            await _unitOfWork.CompleteAsync();
        }
    }
}