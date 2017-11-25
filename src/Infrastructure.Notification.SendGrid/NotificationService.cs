namespace CompanyName.Notebook.NoteTaking.Infrastructure.Notification.SendGrid
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;

    public class NotificationService : INotificationService
    {
        public void SendMessage(string recipient, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(IList<string> recipients, string message)
        {
            throw new NotImplementedException();
        }
    }
}