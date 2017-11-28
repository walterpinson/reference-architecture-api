namespace Test.Integration.Infrastructure.Data.MongoDb
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb;
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;

    [TestFixture]
    public class CategoryRepositoryTester
    {
        private IConfigurationRoot _config;
        private IMapper _mapper;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MongoMappingProfile>();
            });

            _mapper = config.CreateMapper();

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();
            _config = builder.Build();
        }

        [Test]
        public void CanInstantiateCategoryRepository()
        {
            // ARRANGE
            var connectionString = _config.GetConnectionString("NoteTakerTest");

            // ACT
            var subjectUnderTest = new CategoryRepository(connectionString, _mapper);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ICategoryRepository)));
        }

        [Test]
        public void CanAddCategory()
        {
            // ARRANGE
            var connectionString = _config.GetConnectionString("NoteTakerTest");
            ICategoryRepository  subjectUnderTest = new CategoryRepository(connectionString, _mapper);

            var category = MakeCategory();

            // ACT
            var result = subjectUnderTest.Add(category);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(ICategory)));
            Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
        }

        // Private Helper Methods
        ///////////////////////////////////////////////
        private ICategory MakeCategory()
        {
            var category = new Category {
                Id = Guid.NewGuid(),
                Name = "Sports Utility Vehicles",
                Created = DateTime.UtcNow,
                Notes = new List<INote>(new Note[] {new Note("I'm taking note of this note.")}),
                Subscribers = new List<ISubscriber>(new Subscriber[] { new Subscriber(emailAddress: "mickey.mouse@disney.com")})
            };

            return category;
        }
    }
}
