namespace CompanyName.Notebook.NoteTaking.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public class NoteFactory : INoteFactory
    {
        public INote Create(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Must have text to create note.", nameof(text));
            return new Note(text);
        }
    }
}