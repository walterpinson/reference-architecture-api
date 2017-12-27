namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface IRegistrar
    {
        SubscriberDto Subscribe(SecurityContext securityContext, string emailAddress);
        SubscriberDto Subscribe(SecurityContext securityContext, Guid categoryId, string emailAddress);
        void Unsubscribe(SecurityContext securityContext, Guid subscriberId);
        void Unsubscribe(SecurityContext securityContext, Guid categoryId, Guid subscriberId);
    }
}