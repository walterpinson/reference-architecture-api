namespace Test.Unit.Infrastructure.Server
{
    using System;
    using AutoMapper;
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
        private IMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // ARRANGE
            _noteFactory = Substitute.For<INoteFactory>();
            _subscriberFactory = Substitute.For<ISubscriberFactory>();
            _categoryRepository = Substitute.For<ICategoryRepository>();
            _mapper = Substitute.For<IMapper>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _noteFactory = null;
            _subscriberFactory = null;
            _categoryRepository = null;
            _mapper = null;
        }

        [SetUp]
        public void SetUp()
        {
            // ARRANGE
            _noteFactory.ClearReceivedCalls();
            _subscriberFactory.ClearReceivedCalls();
            _categoryRepository.ClearReceivedCalls();
            _mapper.ClearReceivedCalls();
        }

        [Test]
        public void CanConstructNoteTaker()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new NoteTaker(
                _noteFactory,
                _subscriberFactory,
                _categoryRepository,
                _mapper
            );

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(INoteTaker)));
        }
    }
}