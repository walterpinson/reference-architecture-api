namespace Test.Integration.Infrastructure.Data.MongoDb
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb.Models;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using MongoRepository.NetCore;
    using NUnit.Framework;

    [TestFixture]
    public class CategoryRepositoryTester
    {
        private IConfigurationRoot _config;
        private IMapper _mapper;
        private string _connectionString;
        private MongoRepositoryManager<MongoCategory, Guid> _collectionManager;

        
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

            _connectionString = _config.GetConnectionString("NoteTakingTest");
            _collectionManager = new MongoRepositoryManager<MongoCategory, Guid>(_connectionString, "Categories");
            _collectionManager.DropDatabase();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Drop the database
            _collectionManager.DropDatabase();

            // Clean up memory; send to garbage collector
            _mapper = null;
            _config = null;
            _connectionString = null;
            _collectionManager = null;
        }

        [SetUp]
        public void SetUp()
        {
            // Drop the Categories collection
            _collectionManager.Drop();
        }

        [Test]
        public void CanInstantiateCategoryRepository()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ICategoryRepository)));
        }

        [Test]
        public void CanInstantiateCategoryRepositoryWithMongoUrl()
        {
            // ARRANGE
            var mongoUrl = new MongoUrl(_connectionString);

            // ACT
            var subjectUnderTest = new CategoryRepository(mongoUrl, _mapper);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ICategoryRepository)));
        }

        [Test]
        public void CanAddCategory()
        {
            // ARRANGE
            ICategoryRepository  subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            var category = MakeCategory();

            // ACT
            var result = subjectUnderTest.Add(category);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(ICategory)));
            Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void CanDeleteCategory()
        {
            // ARRANGE
            ICategoryRepository  subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            var category = MakeCategory();
            category = subjectUnderTest.Add(category);

            // ACT
            subjectUnderTest.Delete(category.Id);

            // ASSERT
            Assert.That(subjectUnderTest.Get(category.Id), Is.Null);
        }

        [Test]
        public void CanGetCategoryById()
        {
            // ARRANGE
            ICategoryRepository  subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            var category = MakeCategory();
            category = subjectUnderTest.Add(category);

            // ACT
            var result = subjectUnderTest.Get(category.Id);

            // ASSERT
            Assert.That(result.Id, Is.EqualTo(category.Id));
        }

        [Test]
        public void CanGetCategoryByName()
        {
            // ARRANGE
            ICategoryRepository  subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            var expectedName = $"Super Cars {Guid.NewGuid().ToString()}";
            var category = MakeCategory(expectedName);
            category = subjectUnderTest.Add(category);

            // ACT
            var result = subjectUnderTest.GetByName(expectedName);

            // ASSERT
            Assert.That(result.Id, Is.EqualTo(category.Id));
        }

        [Test]
        public void CanModifyCategory()
        {
            // ARRANGE
            ICategoryRepository  subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            var expectedName = "Precious Metals";
            var category = MakeCategory();
            category = subjectUnderTest.Add(category);
            category.ChangeName(expectedName);


            // ACT
            var result = subjectUnderTest.Save(category);

            // ASSERT
            Assert.That(result.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void CanGetAllCategories()
        {
            // ARRANGE
            ICategoryRepository  subjectUnderTest = new CategoryRepository(_connectionString, _mapper);

            var category = MakeCategory();
            category = subjectUnderTest.Add(category);

            // ACT
            var result = subjectUnderTest.GetAll();

            // ASSERT
            Assert.That(result, Is.InstanceOf(typeof(IList<ICategory>)));
        }

        // Private Helper Methods
        ///////////////////////////////////////////////
        private ICategory MakeCategory(string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                name = "Sports Utility Vehicles";
            }

            var category = new Category {
                Name = name,
                Created = DateTime.UtcNow,
                Notes = new List<INote>(new Note[] {new Note("I'm taking note of this note.")}),
                Subscribers = new List<ISubscriber>(new Subscriber[] { new Subscriber(emailAddress: "mickey.mouse@disney.com")})
            };

            return category;
        }
    }
}
