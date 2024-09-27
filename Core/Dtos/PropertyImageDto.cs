using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for property images.
    /// </summary>
    public class PropertyImageDto
    {
        /// <summary>
        /// Property identifier.
        /// </summary>
        [Required(ErrorMessage = "Property ID is required.")]
        public int IdProperty { get; set; }

        /// <summary>
        /// Image file.
        /// </summary>
        [Required(ErrorMessage = "File is required.")]
        public IFormFile File { get; set; } = null!;
    }
}