namespace Test.Unit.Core.Application.Messages
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NoteDtoTester
    {
        [Test]
        public void CanCreateNoteDto()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new NoteDto();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(NoteDto)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(NoteDto)));
        }

        [Test]
        public void CanSetNoteId()
        {
            // ARRANGE
            var expectedId = Guid.NewGuid();
            var subjectUnderTest = new NoteDto();

            // ACT
            subjectUnderTest.Id = expectedId;

            // ASSERT
            Assert.That(subjectUnderTest.Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void CanSetNoteText()
        {
            // ARRANGE
            var expectedText = "Don't to forget to pick up bread from the grocery store.";
            var subjectUnderTest = new NoteDto();

            // ACT
            subjectUnderTest.Text = expectedText;

            // ASSERT
            Assert.That(subjectUnderTest.Text, Is.EqualTo(expectedText));
        }

        [Test]
        public void CanSetNoteCreateDate()
        {
            // ARRANGE
            var expectedCreated = new DateTime(1999, 1, 1);
            var subjectUnderTest = new NoteDto();

            // ACT
            subjectUnderTest.Created = expectedCreated;

            // ASSERT
            Assert.That(subjectUnderTest.Created, Is.EqualTo(expectedCreated));
        }
    }
}
