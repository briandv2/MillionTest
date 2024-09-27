using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for updating a property.
    /// </summary>
    public class UpdatePropertyDto
    {
        /// <summary>
        /// Property identifier.
        /// </summary>
        [Required(ErrorMessage = "Property ID is required.")]
        public int IdProperty { get; set; }

        /// <summary>
        /// Property name.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Property address.
        /// </summary>
        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Property price.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        /// <summary>
        /// Internal code of the property.
        /// </summary>
        [Required(ErrorMessage = "Internal code is required.")]
        [MaxLength(10, ErrorMessage = "Internal code cannot exceed 10 characters.")]
        public string CodeInternal { get; set; } = string.Empty;

        /// <summary>
        /// Year of construction of the property.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Year must be a positive value.")]
        public int? Year { get; set; }

        /// <summary>
        /// Owner identifier of the property.
        /// </summary>
        [Required(ErrorMessage = "Owner ID is required.")]
        public int IdOwner { get; set; }
    }
}