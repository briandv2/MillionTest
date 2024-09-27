using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for property image repository.
    /// </summary>
    public interface IPropertyImageRepository
    {
        /// <summary>
        /// Adds an image to a property asynchronously.
        /// </summary>
        /// <param name="propertyImage">The property image to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddImageToPropertyAsync(PropertyImage propertyImage);
    }
}