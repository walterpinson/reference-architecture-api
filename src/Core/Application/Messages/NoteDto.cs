namespace CompanyName.Notebook.NoteTaking.Core.Application.Messages
{
    using System;

    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}