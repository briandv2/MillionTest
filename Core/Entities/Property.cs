namespace Core.Entities
{
    /// <summary>
    /// Represents a property entity.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Property identifier.
        /// </summary>
        public int IdProperty { get; set; }

        /// <summary>
        /// Name of the property.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Address of the property.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Price of the property.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Internal code of the property.
        /// </summary>
        public string CodeInternal { get; set; } = string.Empty;

        /// <summary>
        /// Year of construction of the property.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Owner identifier of the property.
        /// </summary>
        public int IdOwner { get; set; }

        /// <summary>
        /// Navigation property for the owner.
        /// </summary>
        public virtual Owner IdOwnerNavigation { get; set; } = null!;

        /// <summary>
        /// Collection of property images.
        /// </summary>
        public virtual ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();

        /// <summary>
        /// Collection of property traces.
        /// </summary>
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; } = new List<PropertyTrace>();
    }
}