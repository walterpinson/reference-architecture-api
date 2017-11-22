namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public class Subscriber: ISubscriber
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }

        public Subscriber(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress)) throw new ArgumentException("message", nameof(emailAddress));

            EmailAddress = emailAddress;
            Id = Guid.NewGuid();
        }
    }
}