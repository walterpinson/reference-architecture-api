namespace Test.Unit.Infrastructure.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CategoriesControllerTester
    {
        [Test]
        public void CanConstructCategoriesController()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();

            // ACT
            var subjectUnderTest = new CategoriesController(noteTaker, logger);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(CategoriesController)));
        }

        [Test]
        public void CanGetAllCategories()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();
            var subjectUnderTest = new CategoriesController(noteTaker, logger);

            var expectedCategoryDtos = Substitute.For<IList<CategoryDto>>();

            noteTaker.ListCategories().Returns(expectedCategoryDtos);

            // ACT
            var result = subjectUnderTest.Get();

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).ListCategories();
        }

        [Test]
        public void CanGetCategory()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();
            var subjectUnderTest = new CategoriesController(noteTaker, logger);

            var expectedCategoryDto = Substitute.For<CategoryDto>();
            var expectedId = Guid.NewGuid();

            noteTaker.GetCategoryDetail(expectedId).Returns(expectedCategoryDto);

            // ACT
            var result = subjectUnderTest.Get(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).GetCategoryDetail(expectedId);
        }

        [Test]
        public void CanRenameCategory()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();
            var subjectUnderTest = new CategoriesController(noteTaker, logger);

            var expectedId = Guid.NewGuid();
            var expectedNewName = "Red Dwarfs";
            var expectedUpdatedCategoryDto = Substitute.For<CategoryDto>();
            expectedUpdatedCategoryDto.Name = expectedNewName;

            noteTaker.RenameCategory(expectedId, expectedNewName).Returns(expectedUpdatedCategoryDto);

            // ACT
            var result = subjectUnderTest.Put(expectedId, expectedUpdatedCategoryDto);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).RenameCategory(expectedId, expectedNewName);
        }

        [Test]
        public void CanCreateCategory()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();
            var subjectUnderTest = new CategoriesController(noteTaker, logger);

            var newCategoryMessage = Substitute.For<NewCategoryMessage>();
            var expectedCategoryDto = Substitute.For<CategoryDto>();

            noteTaker.CreateNewCategory(newCategoryMessage).Returns(expectedCategoryDto);

            // ACT
            var result = subjectUnderTest.Post(newCategoryMessage);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).CreateNewCategory(newCategoryMessage);
        }

        [Test]
        public void CanDeleteCategory()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();
            var subjectUnderTest = new CategoriesController(noteTaker, logger);

            var expectedId = Guid.NewGuid();

            // ACT
            var result = subjectUnderTest.Delete(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).RemoveCategory(expectedId);
        }
    }
}
