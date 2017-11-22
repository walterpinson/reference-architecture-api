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
            Mapper.Initialize(cfg => cfg.AddProfile<MessageMappingProfile>());

            // ASSERT
            Mapper.AssertConfigurationIsValid();
        }
    }
}