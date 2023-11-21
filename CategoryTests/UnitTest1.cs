using System;
using System.Collections.Generic;
using Xunit;
using Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Domain.Models.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void Category_Instance_CreatedSuccessfully()
        {
            
            var category = new Category();

           
            Assert.NotNull(category);
        }

        [Fact]
        public void Category_Properties_AssignedCorrectly()
        {
            // Arrange
            var id = 1;
            var title = "Sample Title";
            var description = "Sample Description";
            var dateCreate = DateTime.Now;
            var dateUpdate = DateTime.Now.AddHours(1);
            var proveedores = new List<Product>();

            // Act
            var category = new Category
            {
                Id = id,
                Title = title,
                Description = description,
                DateCreate = dateCreate,
                DateUpdate = dateUpdate,
                Proveedores = proveedores
            };

            // Assert
            Assert.Equal(id, category.Id);
            Assert.Equal(title, category.Title);
            Assert.Equal(description, category.Description);
            Assert.Equal(dateCreate, category.DateCreate);
            Assert.Equal(dateUpdate, category.DateUpdate);
            Assert.Equal(proveedores, category.Proveedores);
        }
    }
}