using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for handling operations related to property images.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageService _propertyImageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyImageController"/> class.
        /// </summary>
        /// <param name="propertyImageService">Service for handling business logic related to property images.</param>
        public PropertyImageController(IPropertyImageService propertyImageService)
        {
            _propertyImageService = propertyImageService;
        }

        /// <summary>
        /// Adds an image to a property.
        /// </summary>
        /// <param name="propertyImageDto">DTO containing the property image data.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the action.</returns>
        [HttpPost("AddPropertyImage")]
        public async Task<IActionResult> AddPropertyImage([FromForm] PropertyImageDto propertyImageDto)
        {
            if (propertyImageDto == null)
                return BadRequest("Property image data is required.");

            try
            {
                await _propertyImageService.AddImageToPropertyAsync(propertyImageDto);
                return Ok("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}