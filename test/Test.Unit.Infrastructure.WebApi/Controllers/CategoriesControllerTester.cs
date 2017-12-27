namespace Test.Unit.Infrastructure.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;
    using NSubstitute;
    using NUnit.Framework;
    using Test.Unit.Infrastructure.WebApi.Controllers.Bases;

    [TestFixture]
    public class CategoriesControllerTester : ControllerTesterTemplate<CategoriesController>
    {
        INoteTaker _noteTaker;
        ILogger<CategoriesController> _logger;

        protected override CategoriesController EstablishContext()
        {
            _noteTaker = Substitute.For<INoteTaker>();
            _logger = Substitute.For<ILogger<CategoriesController>>();
            return new CategoriesController(_noteTaker, _logger);
        }

        protected override void TestCleanup()
        {
            _noteTaker.ClearReceivedCalls();
            _logger.ClearReceivedCalls();
        }
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

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
            var expectedCategoryDtos = Substitute.For<IList<CategoryDto>>();

            _noteTaker.ListCategories(Arg.Any<SecurityContext>()).Returns(expectedCategoryDtos);

            // ACT
            var result = _subjectUnderTest.Get();

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).ListCategories(Arg.Any<SecurityContext>());
        }

        [Test]
        public void CanGetCategory()
        {
            // ARRANGE
            var expectedCategoryDto = Substitute.For<CategoryDto>();
            var expectedId = Guid.NewGuid();

            _noteTaker.GetCategoryDetail(Arg.Any<SecurityContext>(), expectedId).Returns(expectedCategoryDto);

            // ACT
            var result = _subjectUnderTest.Get(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).GetCategoryDetail(Arg.Any<SecurityContext>(), expectedId);
        }

        [Test]
        public void CanRenameCategory()
        {
            // ARRANGE
            var expectedId = Guid.NewGuid();
            var expectedNewName = "Red Dwarfs";
            var expectedUpdatedCategoryDto = Substitute.For<CategoryDto>();
            expectedUpdatedCategoryDto.Name = expectedNewName;

            _noteTaker.RenameCategory(Arg.Any<SecurityContext>(), expectedId, expectedNewName).Returns(expectedUpdatedCategoryDto);

            // ACT
            var result = _subjectUnderTest.Put(expectedId, expectedUpdatedCategoryDto);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).RenameCategory(Arg.Any<SecurityContext>(), expectedId, expectedNewName);
        }

        [Test]
        public void CanCreateCategory()
        {
            // ARRANGE
            var newCategoryMessage = Substitute.For<NewCategoryMessage>();
            var expectedCategoryDto = Substitute.For<CategoryDto>();

            _noteTaker.CreateNewCategory(Arg.Any<SecurityContext>(), newCategoryMessage).Returns(expectedCategoryDto);

            // ACT
            var result = _subjectUnderTest.Post(newCategoryMessage);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).CreateNewCategory(Arg.Any<SecurityContext>(), newCategoryMessage);
        }

        [Test]
        public void CanDeleteCategory()
        {
            // ARRANGE
            var expectedId = Guid.NewGuid();

            // ACT
            var result = _subjectUnderTest.Delete(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).RemoveCategory(Arg.Any<SecurityContext>(), expectedId);
        }
    }
}