namespace Test.Unit.Infrastructure.Server
{
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Server;
    using NUnit.Framework;

    [TestFixture]
    public class MessageMappingProfileTester
    {
        [Test]
        public void MessageMappingConfigurationIsValid()
        {
            // ARRANGE
            // ACT
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MessageMappingProfile>());


            // ASSERT
            configuration.AssertConfigurationIsValid();
        }
    }
}