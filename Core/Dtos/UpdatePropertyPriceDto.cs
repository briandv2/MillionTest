using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for updating the price of a property.
    /// </summary>
    public class UpdatePropertyPriceDto
    {
        /// <summary>
        /// Property identifier.
        /// </summary>
        [Required(ErrorMessage = "Property ID is required.")]
        public int PropertyId { get; set; }

        /// <summary>
        /// New price of the property.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "New price must be a positive value.")]
        public decimal NewPrice { get; set; }
    }
}