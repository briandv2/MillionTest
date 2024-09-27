using Core.Entities;
using Core.Interfaces;
using Infraestructure.DB;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    /// <summary>
    /// Repository for handling operations related to property images.
    /// </summary>
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly MillionTestContext _context;

        /// <summary>
        /// Constructor that injects the database context.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PropertyImageRepository(MillionTestContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds an image to a property and saves the changes to the database.
        /// </summary>
        /// <param name="propertyImage">The property image to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddImageToPropertyAsync(PropertyImage propertyImage)
        {
            if (propertyImage == null)
            {
                throw new ArgumentNullException(nameof(propertyImage));
            }

            await _context.PropertyImages.AddAsync(propertyImage);
            await _context.SaveChangesAsync();
        }
    }
}