namespace Test.Unit.Core.Application.Messages
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class SubscriberDtoTester
    {
        [Test]
        public void CanCreateSubscriberDto()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new SubscriberDto();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(SubscriberDto)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(SubscriberDto)));
        }

        [Test]
        public void CanSetId()
        {
            // ARRANGE
            var expectedId = Guid.NewGuid();
            var subjectUnderTest = new SubscriberDto();

            // ACT
            subjectUnderTest.Id = expectedId;

            // ASSERT
            Assert.That(subjectUnderTest.Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void CanSetEmailAddress()
        {
            // ARRANGE
            var expectedEmailAddress = "mickey.mouse@disnet.com";
            var subjectUnderTest = new SubscriberDto();

            // ACT
            subjectUnderTest.EmailAddress = expectedEmailAddress;

            // ASSERT
            Assert.That(subjectUnderTest.EmailAddress, Is.EqualTo(expectedEmailAddress));
        }
    }
}
