namespace Test.Unit.Infrastructure.WebApi.Controllers.Bases
{
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;

    [TestFixture]
    public abstract class TesterTemplate<TContext> where TContext : Controller
    {
        protected virtual TContext _subjectUnderTest { get; private set; }

        [SetUp]
        public virtual void MainSetup()
        {
            _subjectUnderTest = EstablishContext();
        }

        [TearDown]
        public void Teardown()
        {
            TestCleanup();
        }

        protected abstract TContext EstablishContext();

        protected abstract void TestCleanup();
    }
}