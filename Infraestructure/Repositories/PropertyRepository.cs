using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    /// <summary>
    /// Repository for handling property-related operations.
    /// </summary>
    public class PropertyRepository : IPropertyRepository
    {
        private readonly MillionTestContext _context;

        /// <summary>
        /// Constructor that injects the database context.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PropertyRepository(MillionTestContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Creates a new property and saves the changes to the database.
        /// </summary>
        /// <param name="property">The property to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreatePropertyAsync(Property property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a property by its ID.
        /// </summary>
        /// <param name="id">The ID of the property.</param>
        /// <returns>The found property or null if not found.</returns>
        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(x => x.IdProperty == id);
        }

        /// <summary>
        /// Updates an existing property and saves the changes to the database.
        /// </summary>
        /// <param name="property">The property to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdatePropertyAsync(Property property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a list of properties that match the specified filters.
        /// </summary>
        /// <param name="propertyFilterDto">DTO containing the filters for property search.</param>
        /// <returns>A list of properties that match the filters.</returns>
        public async Task<List<Property>> GetPropertiesAsync(PropertyFilterDto propertyFilterDto)
        {
            if (propertyFilterDto == null)
            {
                throw new ArgumentNullException(nameof(propertyFilterDto));
            }

            var query = _context.Properties.AsQueryable();

            if (propertyFilterDto.IdProperty.HasValue)
                query = query.Where(p => p.IdProperty == propertyFilterDto.IdProperty);
            if (propertyFilterDto.IdOwner.HasValue)
                query = query.Where(p => p.IdOwner == propertyFilterDto.IdOwner);
            if (!string.IsNullOrEmpty(propertyFilterDto.Name))
                query = query.Where(p => p.Name.Contains(propertyFilterDto.Name));
            if (!string.IsNullOrEmpty(propertyFilterDto.Address))
                query = query.Where(p => p.Address.Contains(propertyFilterDto.Address));
            if (propertyFilterDto.Year.HasValue)
                query = query.Where(p => p.Year == propertyFilterDto.Year);
            if (propertyFilterDto.Price.HasValue)
                query = query.Where(p => p.Price == propertyFilterDto.Price);
            if (!string.IsNullOrEmpty(propertyFilterDto.CodeInternal))
                query = query.Where(p => p.CodeInternal.Contains(propertyFilterDto.CodeInternal));

            return await query.ToListAsync();
        }
    }
}