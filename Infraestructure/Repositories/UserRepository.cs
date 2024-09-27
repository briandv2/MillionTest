using Core.Entities;
using Core.Interfaces;
using Infraestructure.DB;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    /// <summary>
    /// Repository for handling user-related operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly MillionTestContext _context;

        /// <summary>
        /// Constructor that injects the database context.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserRepository(MillionTestContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets a user by their username and password.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The found user or null if not found.</returns>
        public async Task<Users?> GetUserByUserNameAndPasswordAsync(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty", nameof(userName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(password));
            }

            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
        }
    }
}