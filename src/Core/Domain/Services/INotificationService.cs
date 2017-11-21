namespace CompanyName.Notebook.NoteTaking.Core.Domain.Services
{
    using System;
    using System.Collections.Generic;

    public interface INotificationService
    {
        void SendMessage(string recipient, string message);
        void SendMessage(IList<string> recipients, string message);
    }
}