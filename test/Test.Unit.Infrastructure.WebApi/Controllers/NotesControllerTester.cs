namespace Test.Unit.Infrastructure.WebApi.Controllers
{
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NotesControllerTester
    {
        [Test]
        public void CanConstructNotesController()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<NotesController>>();

            // ACT
            var subjectUnderTest = new NotesController(noteTaker, logger);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(NotesController)));
        }
    }
}
