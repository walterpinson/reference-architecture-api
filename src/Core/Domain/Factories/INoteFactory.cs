namespace CompanyName.Notebook.NoteTaking.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public interface INoteFactory
    {
        INote Create(string text);
    }
}