namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;

    public class Note
    {
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public DateTime Created { get; private set; }

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