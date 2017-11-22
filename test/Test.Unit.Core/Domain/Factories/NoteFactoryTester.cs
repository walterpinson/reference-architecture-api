namespace Test.Unit.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NoteFactoryTester
    {
        [Test]
        public void CanConstructNoteFactory()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new NoteFactory();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(NoteFactory)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(INoteFactory)));
        }

        [Test]
        public void CanCreateNote()
        {
            // ARRANGE
            var expectedNoteText = "This is just a reminder to go to the store.";
            var subjectUnderTest = new NoteFactory();

            // ACT
            var result = subjectUnderTest.Create(expectedNoteText);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(INote)));
            Assert.That(result.Text, Is.EqualTo(expectedNoteText));
        }

        [Test]
        public void CreateThrowsArgumentExceptionWhenTextNull()
        {
            // ARRANGE
            var expectedExceptionMessage = "Must have text to create note.\nParameter name: text";
            var subjectUnderTest = new NoteFactory();

            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentException>(
                () => subjectUnderTest.Create(null)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
