using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for user login.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Username.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(150, ErrorMessage = "Username cannot exceed 150 characters.")]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// User password.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(400, ErrorMessage = "Password cannot exceed 400 characters.")]
        public string Password { get; set; } = string.Empty;
    }
}