using NUnit.Framework;
using Moq;
using Core.Interfaces;
using Application.Services;
using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infraestructure.Repositories;

namespace MillionTest.Tests.Services
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private Mock<PropertyRepository> _propertyRepositoryMock;
        private PropertyService _propertyService;

        [SetUp]
        public void SetUp()
        {
            _propertyRepositoryMock = new Mock<IPropertyRepository>();
            _propertyService = new PropertyService(_propertyRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllPropertiesAsync_ReturnsListOfProperties()
        {
            // Arrange
            var properties = new List<Property> { new Property { Id = 1, Name = "Test Property" } };
            _propertyRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(properties);

            // Act
            var result = await _propertyService.GetAllPropertiesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Property>>(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task GetPropertyByIdAsync_ValidId_ReturnsProperty()
        {
            // Arrange
            var property = new Property { Id = 1, Name = "Test Property" };
            _propertyRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(property);

            // Act
            var result = await _propertyService.GetPropertyByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Property>(result);
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public async Task GetPropertyByIdAsync_InvalidId_ReturnsNull()
        {
            // Arrange
            _propertyRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Property)null);

            // Act
            var result = await _propertyService.GetPropertyByIdAsync(1);

            // Assert
            Assert.IsNull(result);
        }
    }
}