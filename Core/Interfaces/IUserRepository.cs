using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for user repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a user by username and password asynchronously.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
        Task<Users?> GetUserByUserNameAndPasswordAsync(string userName, string password);
    }
}