namespace Test.Unit.Infrastructure.WebApi.Exceptions
{
    using System;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NoteBookExceptionFilterTester
    {
        [Test]
        public void CanConstructNoteBookExceptionFilter()
        {
            // ARRANGE
            var logger = Substitute.For<ILogger<NoteBookExceptionFilter>>();

            // ACT
            var subjectUnderTest = new NoteBookExceptionFilter(logger);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(NoteBookExceptionFilter)));
        }

        public void OnExceptionHandlesUnauthorized()
        {
            // ARRANGE
            var expectedException = Substitute.For<UnauthorizedAccessException>();
            var expectedHttpContext = Substitute.For<HttpContext>();
            var expectedHttpResponse = Substitute.For<HttpResponse>();
            // var thing = Substitute.For<ExceptionContextCatchBlock>();
            var context = Substitute.For<ExceptionContext>(expectedException, null);

            context.Exception.Returns(expectedException);
            expectedException.GetType().Returns(typeof(UnauthorizedAccessException));
            context.HttpContext.Returns(expectedHttpContext);
            expectedHttpContext.Response.Returns(expectedHttpResponse);

            var logger = Substitute.For<ILogger<NoteBookExceptionFilter>>();
            var subjectUnderTest = new NoteBookExceptionFilter(logger);

            // ACT
            subjectUnderTest.OnException(context);

            // ASSERT
            var temp1 = context.Received(2).Exception;
            expectedException.Received(1).GetType();
            logger.Received(1).LogError(0, expectedException, "Unauthorized Access");
            var temp2 = context.Received(1).HttpContext;
            var temp3 = expectedHttpContext.Received(1).Response;
            expectedHttpResponse.ReceivedWithAnyArgs(1).WriteAsync(Arg.Any<string>());
        }
    }
}
