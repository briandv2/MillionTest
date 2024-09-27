using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    /// <summary>
    /// DTO for the owner.
    /// </summary>
    public class OwnerDto
    {
        /// <summary>
        /// Owner identifier.
        /// </summary>
        public int IdOwner { get; set; }

        /// <summary>
        /// Owner's name.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Owner's address.
        /// </summary>
        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Owner's photo.
        /// </summary>
        public byte[]? Photo { get; set; }

        /// <summary>
        /// Owner's birthday.
        /// </summary>
        public DateOnly? Birthday { get; set; }

        /// <summary>
        /// List of properties owned by the owner.
        /// </summary>
        public virtual ICollection<PropertyDto> Properties { get; set; } = new List<PropertyDto>();
    }
}