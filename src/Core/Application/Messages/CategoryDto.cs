namespace CompanyName.Notebook.NoteTaking.Core.Application.Messages
{
    using System;
    using System.Collections.Generic;

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public IList<NoteDto> Notes { get; set; }
        public IList<SubscriberDto> Subscribers { get; set; }
    }
}