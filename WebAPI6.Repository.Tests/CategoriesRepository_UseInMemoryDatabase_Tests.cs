using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebAPI6.Repository.Interfaces;
using Xunit;

namespace WebAPI6.Repository.Tests
{
    public class CategoriesRepository_UseInMemoryDatabase_Tests : NORTHWND_UTContextTest
    {
        [Fact]
        public async Task GetCategoryById_Test()
        {
            //Arrange
            var categoriesRepository = new CategoriesRepository(DbContext);
            int categoryId = 5;
            string categoryName = "Grains/Cereals";
            //Act
            var result = await categoriesRepository.GetById(categoryId);

            //Assert
            Assert.Equal(categoryId, result.CategoryId);
            Assert.Equal(categoryName, result.CategoryName);

            //Clean up
            DbContext.Dispose();
        }

        [Fact]
        public async Task DeleteCategory_Success_Test()
        {
            //Arrange
            var categoriesRepository = new CategoriesRepository(DbContext);
            int categoryId = 9;

            //Act
            await categoriesRepository.Delete(categoryId);

            var result = await categoriesRepository.GetById(categoryId);

            //Assert
            Assert.True(result == null);

            //Clean up
            DbContext.Dispose();
        }

        [Fact]
        public async Task DeleteCategory_ThrowsException_Test()
        {
            //Arrange
            var categoriesRepository = new CategoriesRepository(DbContext);
            int categoryId = 5;

            //Act
            //await categoriesRepository.Delete(categoryId);
            var caughtException = await Assert.ThrowsAsync<DbUpdateException>(() => categoriesRepository.Delete(categoryId));

            Assert.Contains("An error occurred while saving the entity", caughtException.Message);

            //Clean up
            DbContext.Dispose();
        }
    }
}