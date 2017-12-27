namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;

    public class Registrar : IRegistrar
    {
        public SubscriberDto Subscribe(SecurityContext securityContext, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public SubscriberDto Subscribe(SecurityContext securityContext, Guid categoryId, string emailAddress)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(SecurityContext securityContext, Guid subscriberId)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(SecurityContext securityContext, Guid categoryId, Guid subscriberId)
        {
            throw new NotImplementedException();
        }
    }
}