namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;

    public class Subscriber : ISubscriber
    {
        public SubscriberDto Subscribe(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(Guid subscriberId)
        {
            throw new NotImplementedException();
        }
    }
}