namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface IRegistrar
    {
        SubscriberDto Subscribe(string emailAddress);
        SubscriberDto Subscribe(Guid categoryId, string emailAddress);
        void Unsubscribe(Guid subscriberId);
        void Unsubscribe(Guid categoryId, Guid subscriberId);
    }
}