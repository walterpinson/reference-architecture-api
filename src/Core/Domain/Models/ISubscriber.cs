namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public interface ISubscriber
    {
        Guid Id { get; set; }
        string EmailAddress { get; set; }
    }
}