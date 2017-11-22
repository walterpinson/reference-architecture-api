namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public interface INote
    {
        Guid Id { get; }
        string Text { get; }
        DateTime Created { get; }
    }
}