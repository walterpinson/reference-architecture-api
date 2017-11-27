namespace Test.Unit.Core.Domain.Models
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NoteTester
    {
        [Test]
        public void CanCreateNote()
        {
            // ARRANGE
            var expectedText = "Don't to forget to pick up bread from the grocery store.";

            // ACT
            var subjectUnderTest = new Note(expectedText);

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(Note)));
            Assert.That(subjectUnderTest.Text, Is.EqualTo(expectedText));
            Assert.That(subjectUnderTest.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(subjectUnderTest.Created, Is.LessThanOrEqualTo(DateTime.UtcNow));
        }

        [Test]
        public void DoesThrowArgumentExceptionDefaultConstructor()
        {
            // ARRANGE
            var expectedExceptionMessage = $"New Note must have text.{Environment.NewLine}Parameter name: text";
            
            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentException>(
                () => new Note(null)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }

    }
}
