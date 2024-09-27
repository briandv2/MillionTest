using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for property repository.
    /// </summary>
    public interface IPropertyRepository
    {
        /// <summary>
        /// Creates a new property asynchronously.
        /// </summary>
        /// <param name="property">The property to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreatePropertyAsync(Property property);

        /// <summary>
        /// Gets a property by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the property.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the property if found; otherwise, null.</returns>
        Task<Property?> GetPropertyByIdAsync(int id);

        /// <summary>
        /// Updates an existing property asynchronously.
        /// </summary>
        /// <param name="property">The property to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdatePropertyAsync(Property property);

        /// <summary>
        /// Gets a list of properties based on the provided filter asynchronously.
        /// </summary>
        /// <param name="propertyFilterDto">The filter criteria for the properties.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of properties.</returns>
        Task<List<Property>> GetPropertiesAsync(PropertyFilterDto propertyFilterDto);
    }
}