using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for property filters.
    /// </summary>
    public class PropertyFilterDto
    {
        /// <summary>
        /// Property identifier.
        /// </summary>
        public int? IdProperty { get; set; }

        /// <summary>
        /// Property name.
        /// </summary>
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string? Name { get; set; }

        /// <summary>
        /// Property address.
        /// </summary>
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }

        /// <summary>
        /// Property price.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Internal code of the property.
        /// </summary>
        [MaxLength(10, ErrorMessage = "Internal code cannot exceed 10 characters.")]
        public string? CodeInternal { get; set; }

        /// <summary>
        /// Year of construction of the property.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Year must be a positive value.")]
        public int? Year { get; set; }

        /// <summary>
        /// Owner identifier of the property.
        /// </summary>
        public int? IdOwner { get; set; }
    }
}