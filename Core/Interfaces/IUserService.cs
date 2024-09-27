using Core.Dtos;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for user service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Logs in a user asynchronously.
        /// </summary>
        /// <param name="loginDto">The login DTO containing the username and password.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the login token if successful.</returns>
        Task<string> LoginAsync(LoginDto loginDto);
    }
}