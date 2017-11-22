namespace CompanyName.Notebook.NoteTaking.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public class SubscriberFactory : ISubscriberFactory
    {
        public ISubscriber Create(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress)) throw new ArgumentException("Must have email address to create subscriber.", nameof(emailAddress));
            return new Subscriber(emailAddress);
        }
    }
}