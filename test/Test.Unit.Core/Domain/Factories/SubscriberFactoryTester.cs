namespace Test.Unit.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class SubscriberFactoryTester
    {
        [Test]
        public void CanConstructSubscriberFactory()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new SubscriberFactory();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(SubscriberFactory)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ISubscriberFactory)));
        }

        [Test]
        public void CanCreateSubscriber()
        {
            // ARRANGE
            var expectedEmailAddress = "mickey.mouse@disney.com";
            var subjectUnderTest = new SubscriberFactory();

            // ACT
            var result = subjectUnderTest.Create(expectedEmailAddress);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(ISubscriber)));
            Assert.That(result.EmailAddress, Is.EqualTo(expectedEmailAddress));
        }

        [Test]
        public void CreateThrowsArgumentExceptionWhenEmailNull()
        {
            // ARRANGE
            var expectedExceptionMessage = "Must have email address to create subscriber. (Parameter 'emailAddress')";
            var subjectUnderTest = new SubscriberFactory();

            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentException>(
                () => subjectUnderTest.Create(null)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
