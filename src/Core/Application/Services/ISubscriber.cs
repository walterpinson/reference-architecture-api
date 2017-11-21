namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface ISubscriber
    {
        SubscriberDto Subscribe(string emailAddress);
        void Unsubscribe(Guid subscriberId);
    }
}