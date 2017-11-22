namespace Test.Unit.Infrastructure.Server
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Server;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NoteTakerTester
    {
        private INoteFactory _noteFactory;
        private ISubscriberFactory _subscriberFactory;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // ARRANGE
            _noteFactory = Substitute.For<INoteFactory>();
            _subscriberFactory = Substitute.For<ISubscriberFactory>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _noteFactory = null;
            _subscriberFactory = null;
        }

        [SetUp]
        public void SetUp()
        {
            // ARRANGE
            _noteFactory.ClearReceivedCalls();
            _subscriberFactory.ClearReceivedCalls();
        }

        [Test]
        public void CanConstructNoteTaker()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new NoteTaker();

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(INoteTaker)));
        }
    }
}