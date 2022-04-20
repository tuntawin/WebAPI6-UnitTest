using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI6.Models.Models;
using WebAPI6.Repository.Interfaces;
using WebAPI6.Services;
using Xunit;

namespace WebAPI6.Repository.Tests
{
    public class CategoriesRepository_Moq_Tests
    {
        //Mock only Repository
        [Fact]
        public async void GetCategoryById_Return_Category()
        {
            // Arrange
            var mockRepo = new Mock<ICategoriesRepository>();
            mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(
                    new Category() { CategoryId = 1, CategoryName = "Category 1", Description = "" });

            mockRepo.Setup(repo => repo.GetById(2)).ReturnsAsync(
                    new Category() { CategoryId = 2, CategoryName = "Category 2", Description = "" });

            mockRepo.Setup(repo => repo.GetById(3)).ReturnsAsync(
                    new Category() { CategoryId = 3, CategoryName = "Category 3", Description = "" });

            int categorytId = 2;
            string expectedName = "Category 2";
            var services = new CategoryServices(mockRepo.Object);

            //Act
            var result = await services.GetCategory(categorytId);


            // Assert
            Assert.Equal(expectedName, result.CategoryName);
        }
    }
}
