namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public class Note : INote
    {
        public Guid Id { get; protected set; }
        public string Text { get; protected set; }
        public DateTime Created { get; protected set; }

        public Note(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("New Note must have text.", nameof(text));
            }

            Created = DateTime.UtcNow;
            Id = Guid.NewGuid();
            Text = text;
        }
    }
}