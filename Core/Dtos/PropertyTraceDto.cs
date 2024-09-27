using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for property trace.
    /// </summary>
    public class PropertyTraceDto
    {
        /// <summary>
        /// Property trace identifier.
        /// </summary>
        public int IdPropertyTrace { get; set; }

        /// <summary>
        /// Date of sale.
        /// </summary>
        public DateOnly? DateSale { get; set; }

        /// <summary>
        /// Name of the property trace.
        /// </summary>
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string? Name { get; set; }

        /// <summary>
        /// Value of the property trace.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Value must be a positive number.")]
        public decimal? Value { get; set; }

        /// <summary>
        /// Tax of the property trace.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "Tax must be a positive number.")]
        public decimal? Tax { get; set; }

        /// <summary>
        /// Property identifier.
        /// </summary>
        public int? IdProperty { get; set; }

        /// <summary>
        /// Navigation property for the related property.
        /// </summary>
        public virtual PropertyDto? IdPropertyNavigation { get; set; }
    }
}