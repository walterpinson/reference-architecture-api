namespace Test.Unit.Core.Application.Messages
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NewNoteMessageTester
    {
        [Test]
        public void CanCreateNewNoteMessage()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new NewNoteMessage();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(NewNoteMessage)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(NewNoteMessage)));
        }

        [Test]
        public void CanSetText()
        {
            // ARRANGE
            var expectedText = "Don't to forget to pick up bread from the grocery store.";
            var subjectUnderTest = new NewNoteMessage();

            // ACT
            subjectUnderTest.Text = expectedText;

            // ASSERT
            Assert.That(subjectUnderTest.Text, Is.EqualTo(expectedText));
        }
    }
}
