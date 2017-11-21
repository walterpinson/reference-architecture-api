namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public interface INote
    {
        Guid Id { get; set; }
        string Text { get; set; }
        DateTime Created { get; set; }
    }
}