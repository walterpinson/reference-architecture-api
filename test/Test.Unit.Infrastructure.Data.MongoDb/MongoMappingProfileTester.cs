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
            Mapper.Initialize(cfg => cfg.AddProfile<MongoMappingProfile>());

            // ASSERT
            Mapper.AssertConfigurationIsValid();
        }
    }
}