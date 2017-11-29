namespace Test.Unit.Infrastructure.WebApi.Exceptions
{
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Exceptions;
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
    }
}
