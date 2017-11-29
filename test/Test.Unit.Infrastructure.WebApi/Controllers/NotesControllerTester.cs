namespace Test.Unit.Infrastructure.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
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

         [Test]
        public void CanGetNotes()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<NotesController>>();
            var subjectUnderTest = new NotesController(noteTaker, logger);

            var expectedNoteDtos = Substitute.For<IList<NoteDto>>();

            noteTaker.ListNotes().Returns(expectedNoteDtos);

            // ACT
            var result = subjectUnderTest.Get();

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).ListNotes();
        }

         [Test]
        public void CanCreateNote()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<NotesController>>();
            var subjectUnderTest = new NotesController(noteTaker, logger);

            var newNoteMessage = Substitute.For<NewNoteMessage>();
            var expectedNoteDto = Substitute.For<NoteDto>();

            noteTaker.TakeNote(newNoteMessage).Returns(expectedNoteDto);

            // ACT
            var result = subjectUnderTest.Post(newNoteMessage);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).TakeNote(newNoteMessage);
        }

         [Test]
        public void CanDeleteNote()
        {
            // ARRANGE
            var noteTaker = Substitute.For<INoteTaker>();
            var logger = Substitute.For<ILogger<NotesController>>();
            var subjectUnderTest = new NotesController(noteTaker, logger);

            var expectedId = Guid.NewGuid();

            // ACT
            var result = subjectUnderTest.Delete(expectedId);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            noteTaker.Received(1).RemoveNote(expectedId);
        }
   }
}
