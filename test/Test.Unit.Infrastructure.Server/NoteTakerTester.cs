namespace Test.Unit.Infrastructure.Server
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Server;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class NoteTakerTester
    {
        private INoteFactory _noteFactory;
        private ISubscriberFactory _subscriberFactory;
        private ICategoryRepository _categoryRepository;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // ARRANGE
            _noteFactory = Substitute.For<INoteFactory>();
            _subscriberFactory = Substitute.For<ISubscriberFactory>();
            _categoryRepository = Substitute.For<ICategoryRepository>();
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
            var subjectUnderTest = new NoteTaker(
                _noteFactory,
                _subscriberFactory,
                _categoryRepository
            );

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(INoteTaker)));
        }
    }
}