using System;

namespace Core.Entities
{
    /// <summary>
    /// Represents a property trace entity.
    /// </summary>
    public partial class PropertyTrace
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
        /// Name of the trace.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Value of the property.
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Tax applied to the property.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// Property identifier.
        /// </summary>
        public int? IdProperty { get; set; }

        /// <summary>
        /// Navigation property for the property.
        /// </summary>
        public virtual Property? IdPropertyNavigation { get; set; }
    }
}
