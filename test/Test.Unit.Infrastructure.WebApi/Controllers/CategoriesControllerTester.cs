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

    [TestFixture]
    public class CategoriesControllerTester
    {
        private ControllerContext _controllerContext;
        private HttpContext _httpContext;
        private IIdentity _identity;
        private ClaimsPrincipal _principal;
        private HttpRequest _request;
        private IHeaderDictionary _headers;

        private DefaultHttpContext _defaultHttpContext;

        CategoriesController _subjectUnderTest;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Set up the HTTP context
            //// 1. Mock a principal
            _identity = Substitute.For<IIdentity>();
            _principal = new ClaimsPrincipal(_identity);
            //// 2. Mock a request
            _request = Substitute.For<HttpRequest>();

            //// 3. Mock an HttpContext and wire up the Principal and Request
            _httpContext = Substitute.For<HttpContext>();
            _httpContext.User.Returns(_principal);
            _httpContext.Request.Returns(_request);
            
            // Set up the controller context
            _controllerContext = new ControllerContext();
            _controllerContext.HttpContext = _httpContext;

            // Initialize User.Identity.Name value for the controller context.
            _identity.Name.Returns("peoplefluent|00112233445566");

            // Initialize the request headers
            _headers = new HeaderDictionary();
            _headers.Add("Authorization", "Bearer abc123");
            _request.Headers.Returns(_headers);

            // Initialize the request method and path
            _request.Method = "GET";
            _request.Path = "/api/v1/categories";
            _request.QueryString = new QueryString("");



            ////////////////////////////////////////////////////////////////
            // STUFF THAT WAS TRIED BUT DIDN'T NECESSARILY WORK
            // Maybe next time
            ////////////////////////////////////////////////////////////////
            // _controllerContext = Substitute.For<ControllerContext>();
            // _principal = Substitute.For<IPrincipal>();
            // _principal.Identity.Returns(_identity);
            // _controllerContext.HttpContext.Returns(_httpContext);


            // Let's try the whole thing using the DefaultHttpContext
            // _defaultHttpContext = new DefaultHttpContext();
            // _controllerContext.HttpContext = _defaultHttpContext;

            // _defaultHttpContext.User = _principal;
            // _defaultHttpContext.Request.Headers["Authorization"] = "Bearer abc123";

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
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<CategoriesController>>();
            var subjectUnderTest = new CategoriesController(noteTaker, logger);
            
            subjectUnderTest.ControllerContext = _controllerContext;

            var expectedCategoryDtos = Substitute.For<IList<CategoryDto>>();

            noteTaker.ListCategories(Arg.Any<SecurityContext>()).Returns(expectedCategoryDtos);

            // ACT
            var result = subjectUnderTest.Get();

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).ListCategories(Arg.Any<SecurityContext>());
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

            noteTaker.GetCategoryDetail(Arg.Any<SecurityContext>(), expectedId).Returns(expectedCategoryDto);

            // ACT
            var result = subjectUnderTest.Get(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).GetCategoryDetail(Arg.Any<SecurityContext>(), expectedId);
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

            noteTaker.RenameCategory(Arg.Any<SecurityContext>(), expectedId, expectedNewName).Returns(expectedUpdatedCategoryDto);

            // ACT
            var result = subjectUnderTest.Put(expectedId, expectedUpdatedCategoryDto);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).RenameCategory(Arg.Any<SecurityContext>(), expectedId, expectedNewName);
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

            noteTaker.CreateNewCategory(Arg.Any<SecurityContext>(), newCategoryMessage).Returns(expectedCategoryDto);

            // ACT
            var result = subjectUnderTest.Post(newCategoryMessage);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).CreateNewCategory(Arg.Any<SecurityContext>(), newCategoryMessage);
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
            noteTaker.Received(1).RemoveCategory(Arg.Any<SecurityContext>(), expectedId);
        }

    //     private CategoriesController BuildController()
    //     {
    //         _subjectUnderTest = new CategoriesController(noteTaker, logger);
    //     }
    }
}