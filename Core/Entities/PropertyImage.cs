using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Represents a property image entity.
    /// </summary>
    public partial class PropertyImage
    {
        /// <summary>
        /// Property image identifier.
        /// </summary>
        public int IdPropertyImage { get; set; }

        /// <summary>
        /// Property identifier.
        /// </summary>
        public int IdProperty { get; set; }

        /// <summary>
        /// Image file of the property.
        /// </summary>
        public byte[]? ImageFile { get; set; }

        /// <summary>
        /// File name of the image.
        /// </summary>
        public string? FileName { get; set; }

        /// <summary>
        /// Content type of the image.
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// Indicates if the image is enabled.
        /// </summary>
        public bool? Enable { get; set; }

        /// <summary>
        /// Navigation property for the property.
        /// </summary>
        public virtual Property IdPropertyNavigation { get; set; } = null!;
    }
}