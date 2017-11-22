namespace CompanyName.Notebook.NoteTaking.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public interface ISubscriberFactory
    {
        ISubscriber Create(string emailAddress);
    }
}