namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public interface ICategory
    {
        Guid Id { get; }
        string Name { get; }
        DateTime Created { get; }
        IList<INote> Notes { get; }
        IList<ISubscriber> Subscribers { get; }

        INote AddNote(string text);
        void RemoveNote(Guid Id);
        INote RevealNote(Guid id);
        IList<INote> RevealNotes();
        ISubscriber AddSubscriber(string emailAddress);
        void RemoveSubscriber(Guid id);
        void ChangeName(string name);
    }
}