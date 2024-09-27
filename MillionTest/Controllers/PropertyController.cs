using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyController"/> class.
        /// </summary>
        /// <param name="propertyService">The property service.</param>
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Creates a new property.
        /// </summary>
        /// <param name="propertyDto">The property DTO.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] PropertyDto propertyDto)
        {
            if (propertyDto == null)
                return BadRequest("Property data is required.");

            try
            {
                await _propertyService.CreatePropertyAsync(propertyDto);
                return Ok("Property created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the price of an existing property.
        /// </summary>
        /// <param name="updatePropertyPriceDto">The DTO containing the property ID and new price.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        [HttpPut("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice([FromBody] UpdatePropertyPriceDto updatePropertyPriceDto)
        {
            if (updatePropertyPriceDto == null)
                return BadRequest("Update data is required.");

            try
            {
                await _propertyService.UpdatePriceAsync(updatePropertyPriceDto);
                return Ok("Property price updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing property.
        /// </summary>
        /// <param name="updatePropertyDto">The DTO containing the updated property details.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        [HttpPut("UpdateProperty")]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyDto updatePropertyDto)
        {
            if (updatePropertyDto == null)
                return BadRequest("Update data is required.");

            try
            {
                await _propertyService.UpdatePropertyAsync(updatePropertyDto);
                return Ok("Property updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Lists properties based on the provided filter.
        /// </summary>
        /// <param name="propertyFilterDto">The filter criteria for the properties.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        [HttpPost("ListPropertiesByFilter")]
        public async Task<IActionResult> ListPropertiesByFilter([FromBody] PropertyFilterDto propertyFilterDto)
        {
            try
            {
                var propertyList = await _propertyService.GetPropertiesAsync(propertyFilterDto);
                return Ok(propertyList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}