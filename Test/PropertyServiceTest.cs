using NUnit.Framework;
using Moq;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Application.Services;


namespace Application.Tests.Services
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private Mock<IPropertyRepository> _propertyRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private PropertyService _propertyService;

        [SetUp]
        public void SetUp()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();
            _mapperMock = new Mock<IMapper>();
            _propertyService = new PropertyService(_propertyRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task CreatePropertyAsync_ShouldCallRepositoryWithMappedProperty()
        {
            // Arrange
            var propertyDto = new PropertyDto { Name = "Test Property", Address = "Test Address", Price = 100000, CodeInternal = "TP001", Year = 2021, IdOwner = 1 };
            var property = new Property { Name = "Test Property", Address = "Test Address", Price = 100000, CodeInternal = "TP001", Year = 2021, IdOwner = 1 };

            _mapperMock.Setup(m => m.Map<Property>(propertyDto)).Returns(property);

            // Act
            await _propertyService.CreatePropertyAsync(propertyDto);

            // Assert
            _propertyRepositoryMock.Verify(r => r.CreatePropertyAsync(property), Times.Once);
        }

        [Test]
        public void UpdatePriceAsync_ShouldThrowKeyNotFoundException_WhenPropertyDoesNotExist()
        {
            // Arrange
            var updatePropertyPriceDto = new UpdatePropertyPriceDto { PropertyId = 1, NewPrice = 200000 };

            _propertyRepositoryMock.Setup(r => r.GetPropertyByIdAsync(updatePropertyPriceDto.PropertyId)).ReturnsAsync((Property)null);

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _propertyService.UpdatePriceAsync(updatePropertyPriceDto));
        }

        [Test]
        public async Task UpdatePriceAsync_ShouldUpdatePropertyPrice_WhenPropertyExists()
        {
            // Arrange
            var updatePropertyPriceDto = new UpdatePropertyPriceDto { PropertyId = 1, NewPrice = 200000 };
            var property = new Property { IdProperty = 1, Price = 100000 };

            _propertyRepositoryMock.Setup(r => r.GetPropertyByIdAsync(updatePropertyPriceDto.PropertyId)).ReturnsAsync(property);

            // Act
            await _propertyService.UpdatePriceAsync(updatePropertyPriceDto);

            // Assert
            Assert.AreEqual(updatePropertyPriceDto.NewPrice, property.Price);
            _propertyRepositoryMock.Verify(r => r.UpdatePropertyAsync(property), Times.Once);
        }

        [Test]
        public void UpdatePropertyAsync_ShouldThrowKeyNotFoundException_WhenPropertyDoesNotExist()
        {
            // Arrange
            var updatePropertyDto = new UpdatePropertyDto { IdProperty = 1, Name = "Updated Property", Address = "Updated Address", Price = 200000, CodeInternal = "UP001", Year = 2022, IdOwner = 1 };

            _propertyRepositoryMock.Setup(r => r.GetPropertyByIdAsync(updatePropertyDto.IdProperty)).ReturnsAsync((Property)null);

            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _propertyService.UpdatePropertyAsync(updatePropertyDto));
        }

        [Test]
        public async Task UpdatePropertyAsync_ShouldUpdateProperty_WhenPropertyExists()
        {
            // Arrange
            var updatePropertyDto = new UpdatePropertyDto { IdProperty = 1, Name = "Updated Property", Address = "Updated Address", Price = 200000, CodeInternal = "UP001", Year = 2022, IdOwner = 1 };
            var property = new Property { IdProperty = 1, Name = "Old Property", Address = "Old Address", Price = 100000, CodeInternal = "OP001", Year = 2021, IdOwner = 1 };

            _propertyRepositoryMock.Setup(r => r.GetPropertyByIdAsync(updatePropertyDto.IdProperty)).ReturnsAsync(property);
            _mapperMock.Setup(m => m.Map(updatePropertyDto, property)).Returns(property);

            // Act
            await _propertyService.UpdatePropertyAsync(updatePropertyDto);

            // Assert
            _propertyRepositoryMock.Verify(r => r.UpdatePropertyAsync(property), Times.Once);
        }

        [Test]
        public async Task GetPropertiesAsync_ShouldReturnMappedPropertyList()
        {
            // Arrange
            var propertyFilterDto = new PropertyFilterDto { Name = "Test" };
            var propertyList = new List<Property> { new Property { Name = "Test Property" } };
            var propertyDtoList = new List<PropertyDto> { new PropertyDto { Name = "Test Property" } };

            _propertyRepositoryMock.Setup(r => r.GetPropertiesAsync(propertyFilterDto)).ReturnsAsync(propertyList);
            _mapperMock.Setup(m => m.Map<List<PropertyDto>>(propertyList)).Returns(propertyDtoList);

            // Act
            var result = await _propertyService.GetPropertiesAsync(propertyFilterDto);

            // Assert
            Assert.AreEqual(propertyDtoList, result);
        }
    }
}