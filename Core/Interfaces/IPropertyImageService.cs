using Core.Dtos;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for property image service.
    /// </summary>
    public interface IPropertyImageService
    {
        /// <summary>
        /// Adds an image to a property asynchronously.
        /// </summary>
        /// <param name="propertyImageDto">The property image DTO to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddImageToPropertyAsync(PropertyImageDto propertyImageDto);
    }
}