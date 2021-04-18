namespace Test.Unit.Infrastructure.Data.MongoDb
{
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb;
    using NUnit.Framework;

    [TestFixture]
    public class MongoMappingProfileTester
    {
        [Test]
        public void MongoMappingConfigurationIsValid()
        {
            // ARRANGE
            // ACT
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MongoMappingProfile>());

            // ASSERT
            configuration.AssertConfigurationIsValid();
        }
    }
}