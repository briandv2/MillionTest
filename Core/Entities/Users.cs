namespace Core.Entities
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Username of the user.
        /// </summary>
        public required string UserName { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        public required string Password { get; set; }
    }
}