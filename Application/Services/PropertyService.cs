using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Service for managing properties.
    /// </summary>
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyService"/> class.
        /// </summary>
        /// <param name="propertyRepository">The property repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new property asynchronously.
        /// </summary>
        /// <param name="propertyDto">The property DTO to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreatePropertyAsync(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            await _propertyRepository.CreatePropertyAsync(property);
        }

        /// <summary>
        /// Updates the price of an existing property asynchronously.
        /// </summary>
        /// <param name="updatePropertyPriceDto">The DTO containing the property ID and new price.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the property does not exist.</exception>
        public async Task UpdatePriceAsync(UpdatePropertyPriceDto updatePropertyPriceDto)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(updatePropertyPriceDto.PropertyId);
            if (property == null)
                throw new KeyNotFoundException("Property does not exist");

            property.Price = updatePropertyPriceDto.NewPrice;
            await _propertyRepository.UpdatePropertyAsync(property);
        }

        /// <summary>
        /// Updates an existing property asynchronously.
        /// </summary>
        /// <param name="updatePropertyDto">The DTO containing the updated property details.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the property does not exist.</exception>
        public async Task UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(updatePropertyDto.IdProperty);
            if (property == null)
                throw new KeyNotFoundException("Property does not exist");

            var propertyUpdate = _mapper.Map(updatePropertyDto, property);
            await _propertyRepository.UpdatePropertyAsync(propertyUpdate);
        }

        /// <summary>
        /// Gets a list of properties based on the provided filter asynchronously.
        /// </summary>
        /// <param name="propertyFilterDto">The filter criteria for the properties.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of property DTOs.</returns>
        public async Task<List<PropertyDto>> GetPropertiesAsync(PropertyFilterDto propertyFilterDto)
        {
            var propertyList = await _propertyRepository.GetPropertiesAsync(propertyFilterDto);
            return _mapper.Map<List<PropertyDto>>(propertyList);
        }
    }
}