using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI6.Models.Models;
using WebAPI6.Repository;
using WebAPI6.Repository.Interfaces;
using Xunit;
using Moq;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Services.Tests
{
    public class CategoriesRepository_UseInMemoryDatabase_Tests
    {
        private static DbContextOptions<NORTHWND_UTContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<NORTHWND_UTContext>();
            builder.UseInMemoryDatabase(databaseName: "TestDatabase")
                   .UseInternalServiceProvider(serviceProvider);


            // Insert seed data into the database using one instance of the context
            using (var context = new NORTHWND_UTContext(builder.Options))
            {
                context.Categories.Add(new Category { CategoryId = 1, CategoryName = "Category 1", Description = "" });
                context.Categories.Add(new Category { CategoryId = 2, CategoryName = "Category 2", Description = "" });
                context.Categories.Add(new Category { CategoryId = 5, CategoryName = "Category 5", Description = "" });
                context.SaveChanges();
            }

            return builder.Options;
        }
               
        [Fact]
        public async void GetAllCategories_InMemoryDatabase_Test()
        {

            // Use a clean instance of the context to run the test
            using (var context = new NORTHWND_UTContext(CreateNewContextOptions()))
            {
                ICategoriesRepository categoryRepo = new CategoriesRepository(context);
                List<Category> categories = (List<Category>)await categoryRepo.GetAll();

                Assert.Equal(3, categories.Count);
            }
        }
    }
}