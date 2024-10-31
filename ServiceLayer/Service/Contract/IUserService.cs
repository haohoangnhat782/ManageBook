using ApplicationLayer.DTOs;

namespace ApplicationLayer.Service.Contract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(object id);
        Task CreateUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
        Task DeleteUserAsync(object id);
    }
    }