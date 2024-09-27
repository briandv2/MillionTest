using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Service for managing property images.
    /// </summary>
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _propertyImageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyImageService"/> class.
        /// </summary>
        /// <param name="propertyImageRepository">The property image repository.</param>
        public PropertyImageService(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }

        /// <summary>
        /// Adds an image to a property asynchronously.
        /// </summary>
        /// <param name="propertyImageDto">The property image DTO to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown when the file is null or empty.</exception>
        public async Task AddImageToPropertyAsync(PropertyImageDto propertyImageDto)
        {
            if (propertyImageDto.File == null || propertyImageDto.File.Length == 0)
                throw new ArgumentException("File is empty");

            using var memoryStream = new MemoryStream();
            await propertyImageDto.File.CopyToAsync(memoryStream);

            var propertyImage = new PropertyImage
            {
                IdProperty = propertyImageDto.IdProperty,
                ImageFile = memoryStream.ToArray(),
                ContentType = propertyImageDto.File.ContentType,
                FileName = propertyImageDto.File.FileName
            };

            await _propertyImageRepository.AddImageToPropertyAsync(propertyImage);
        }
    }
}