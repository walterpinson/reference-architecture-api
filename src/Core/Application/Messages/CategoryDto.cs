namespace CompanyName.Notebook.NoteTaking.Core.Application.Messages
{
    using System;
    using System.Collections.Generic;

    public class CategoryDto
    {
        Guid Id { get; }
        string Name { get; }
        DateTime Created { get; }
        IList<NoteDto> Notes { get; }
        IList<SubscriberDto> Subscribers { get; }
    }
}