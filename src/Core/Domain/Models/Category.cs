namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;

    public class Category : ICategory
    {
        private readonly INoteFactory _noteFactory;
        private readonly ISubscriberFactory _subscriberFactory;

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Created { get; protected set; }
        public IList<INote> Notes { get; protected set; }
        public IList<ISubscriber> Subscribers { get; protected set; }

        public Category()
        {
        }

        public Category(string name, INoteFactory noteFactory, ISubscriberFactory subscriberFactory)
        {
            Name = (!string.IsNullOrEmpty(name)) ? name : throw new ArgumentException("New Note must have name.", nameof(name));
            _noteFactory = noteFactory ?? throw new ArgumentNullException(nameof(noteFactory));
            _subscriberFactory = subscriberFactory ?? throw new ArgumentNullException(nameof(subscriberFactory));

            Created = DateTime.UtcNow;
        }

        public INote AddNote(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Note text required.", nameof(text));
            }

            var note = _noteFactory.Create(text);

            if (null == Notes)
                Notes = new List<INote>();
            
            Notes.Add(note);

            return note;
        }

        public void RemoveNote(Guid Id)
        {
            throw new NotImplementedException();
        }

        public INote RevealNote(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<INote> RevealNotes()
        {
            throw new NotImplementedException();
        }

        public ISubscriber AddSubscriber(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public ISubscriber RemoveSubscriber(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}