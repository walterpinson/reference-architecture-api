namespace Test.Unit.Infrastructure.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;
    using Test.Unit.Infrastructure.WebApi.Controllers.Bases;

    [TestFixture]
    public class NotesControllerTester : ControllerTesterTemplate<NotesController>
    {
        INoteTaker _noteTaker;
        ILogger<NotesController> _logger;

        protected override NotesController EstablishContext()
        {
            _noteTaker = Substitute.For<INoteTaker>();
            _logger = Substitute.For<ILogger<NotesController>>();
            return new NotesController(_noteTaker, _logger);
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

        [Test]
        public void CanGetNotes()
        {
            // ARRANGE
            var expectedNoteDtos = Substitute.For<IList<NoteDto>>();

            _noteTaker.ListNotes(Arg.Any<SecurityContext>()).Returns(expectedNoteDtos);

            // ACT
            var result = _subjectUnderTest.Get();

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).ListNotes(Arg.Any<SecurityContext>());
        }

        [Test]
        public void CanCreateNote()
        {
            // ARRANGE
            var newNoteMessage = Substitute.For<NewNoteMessage>();
            var expectedNoteDto = Substitute.For<NoteDto>();

            _noteTaker.TakeNote(Arg.Any<SecurityContext>(), newNoteMessage).Returns(expectedNoteDto);

            // ACT
            var result = _subjectUnderTest.Post(newNoteMessage);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).TakeNote(Arg.Any<SecurityContext>(), newNoteMessage);
        }

         [Test]
        public void CanDeleteNote()
        {
            // ARRANGE
            var expectedId = Guid.NewGuid();

            // ACT
            var result = _subjectUnderTest.Delete(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _noteTaker.Received(1).RemoveNote(Arg.Any<SecurityContext>(), expectedId);
        }
    }
}
