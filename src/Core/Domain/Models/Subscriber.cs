namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public class Subscriber: ISubscriber
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
    }
}