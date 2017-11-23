namespace CompanyName.Notebook.NoteTaking.Core.Application.Messages
{
    using System;
    using System.Collections.Generic;

    public class CategoryDto
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime Created { get; }
        public IList<NoteDto> Notes { get; }
        public IList<SubscriberDto> Subscribers { get; }
    }
}