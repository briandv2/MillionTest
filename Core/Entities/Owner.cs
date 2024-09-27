namespace Core.Entities
{
    /// <summary>
    /// Represents an owner entity.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Owner identifier.
        /// </summary>
        public int IdOwner { get; set; }

        /// <summary>
        /// Name of the owner.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Address of the owner.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Photo of the owner.
        /// </summary>
        public byte[]? Photo { get; set; }

        /// <summary>
        /// Birthday of the owner.
        /// </summary>
        public DateOnly? Birthday { get; set; }

        /// <summary>
        /// Collection of properties owned by the owner.
        /// </summary>
        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}