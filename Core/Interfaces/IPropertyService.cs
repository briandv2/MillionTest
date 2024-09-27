using Core.Dtos;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for property service.
    /// </summary>
    public interface IPropertyService
    {
        /// <summary>
        /// Creates a new property asynchronously.
        /// </summary>
        /// <param name="propertyDto">The property DTO to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreatePropertyAsync(PropertyDto propertyDto);

        /// <summary>
        /// Updates the price of an existing property asynchronously.
        /// </summary>
        /// <param name="updatePropertyPriceDto">The DTO containing the property ID and new price.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdatePriceAsync(UpdatePropertyPriceDto updatePropertyPriceDto);

        /// <summary>
        /// Updates an existing property asynchronously.
        /// </summary>
        /// <param name="updatePropertyDto">The DTO containing the updated property details.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto);

        /// <summary>
        /// Gets a list of properties based on the provided filter asynchronously.
        /// </summary>
        /// <param name="propertyFilterDto">The filter criteria for the properties.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of property DTOs.</returns>
        Task<List<PropertyDto>> GetPropertiesAsync(PropertyFilterDto propertyFilterDto);
    }
}