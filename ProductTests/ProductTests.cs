using System;
using Xunit;
using Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Domain.Models.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Instance_CreatedSuccessfully()
        {
            // Arrange
            // Act
            var product = new Product();

            // Assert
            Assert.NotNull(product);
        }

        [Fact]
        public void Product_Properties_AssignedCorrectly()
        {
            // Arrange
            var id = 1;
            var softwareName = "Sample Software";
            var price = 99.99m;
            var description = "Sample Description";
            var urlImagePreview = "https://example.com/image.jpg";
            var dateCreate = DateTime.Now;
            var dateUpdate = DateTime.Now.AddDays(1);
            var categoryId = 42;
            var category = new Category();  

            // Act
            var product = new Product
            {
                Id = id,
                SoftwareName = softwareName,
                Price = price,
                Description = description,
                UrlImagePreview = urlImagePreview,
                DateCreate = dateCreate,
                DateUpdate = dateUpdate,
                CategoryId = categoryId,
                Category = category
            };

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(softwareName, product.SoftwareName);
            Assert.Equal(price, product.Price);
            Assert.Equal(description, product.Description);
            Assert.Equal(urlImagePreview, product.UrlImagePreview);
            Assert.Equal(dateCreate, product.DateCreate);
            Assert.Equal(dateUpdate, product.DateUpdate);
            Assert.Equal(categoryId, product.CategoryId);
            Assert.Equal(category, product.Category);
        }
    }
}