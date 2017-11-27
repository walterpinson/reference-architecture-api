namespace Test.Unit.Core.Domain.Models
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CategoryTester
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
        public void CanCreateCategoryWithNoInput()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new Category();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(Category)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ICategory)));
            Assert.That(subjectUnderTest.Id, Is.EqualTo(Guid.Empty));
        }

        [Test]
        public void CanCreateCategory()
        {
            // ARRANGE
            string expectedName = "Verbose Notes";

            // ACT
            var subjectUnderTest = new Category(expectedName, _noteFactory, _subscriberFactory);

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(Category)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ICategory)));
            Assert.That(subjectUnderTest.Name, Is.EqualTo(expectedName));
            Assert.That(subjectUnderTest.Created, Is.LessThanOrEqualTo(DateTime.UtcNow));
        }

        [Test]
        public void ConstructorThrowsArgumentExceptionWhenNameNull()
        {
            // ARRANGE
            var expectedExceptionMessage = $"New Note must have name.{Environment.NewLine}Parameter name: name";

            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentException>(
                () => new Category(null, _noteFactory, _subscriberFactory)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void ConstructorThrowsArgumentNullExceptionWhenNoteFactoryNull()
        {
            // ARRANGE
            string expectedName = "Verbose Notes";
            var expectedExceptionMessage = $"Value cannot be null.{Environment.NewLine}Parameter name: noteFactory";

            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Category(expectedName, null, _subscriberFactory)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void ConstructorThrowsArgumentNullExceptionWhenSubscriberFactoryNull()
        {
            // ARRANGE
            string expectedName = "Verbose Notes";
            var expectedExceptionMessage = $"Value cannot be null.{Environment.NewLine}Parameter name: subscriberFactory";

            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentNullException>(
                () => new Category(expectedName, _noteFactory, null)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CanAddNote()
        {
            // ARRANGE
            string expectedName = "Verbose Notes";
            string expectedNoteText = "This is just a reminder to go to the store.";
            var expectedNote = Substitute.For<INote>();
            var subjectUnderTest = new Category(expectedName, _noteFactory, _subscriberFactory);

            _noteFactory.Create(expectedNoteText).Returns(expectedNote);

            // ACT
            var result = subjectUnderTest.AddNote(expectedNoteText);

            // ASSERT
            Assert.That(result, Is.InstanceOf(typeof(INote)));
            Assert.That(result, Is.SameAs(expectedNote));
            Assert.That(subjectUnderTest.Notes, Is.Not.Null);
            Assert.That(subjectUnderTest.Notes.Count, Is.EqualTo(1));
            _noteFactory.Received(1).Create(expectedNoteText);
        }

        [Test]
        public void AddNoteThrowsArgumentExceptionWhenTextNull()
        {
            // ARRANGE
            var expectedName = "Verbose Notes";
            string expectedNoteText = null;
            var expectedExceptionMessage = $"Note text required.{Environment.NewLine}Parameter name: text";

            var subjectUnderTest = new Category(expectedName, _noteFactory, _subscriberFactory);

            // ACT
            // ASSERT
            var ex = Assert.Throws<ArgumentException>(
                () => subjectUnderTest.AddNote(expectedNoteText)
            );
            Assert.That(ex.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void CanRemoveNote()
        {
            // ARRANGE
            string expectedName = "Verbose Notes";
            string expectedNoteText = "This is just a reminder to go to the store.";
            var expectedId = Guid.NewGuid();
            var expectedNote = Substitute.For<INote>();
            var subjectUnderTest = new Category(expectedName, _noteFactory, _subscriberFactory);

            _noteFactory.Create(expectedNoteText).Returns(expectedNote);
            expectedNote.Id.Returns(expectedId);
            subjectUnderTest.AddNote(expectedNoteText);
            Assert.That(subjectUnderTest.Notes.Count, Is.EqualTo(1));

            // ACT
            subjectUnderTest.RemoveNote(expectedId);

            // ASSERT
            Assert.That(subjectUnderTest.Notes.Count, Is.EqualTo(0));
            _noteFactory.Received(1).Create(expectedNoteText);
        }
    }
}
