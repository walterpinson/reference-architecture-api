namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public void RemoveNote(Guid id)
        {
            if(Guid.Empty == id) return;
            if(null == Notes || Notes.Count < 1) return;

            Notes.Remove(Notes.FirstOrDefault(note => note.Id == id));
        }

        public INote RevealNote(Guid id)
        {
            if(null == Notes || Notes.Count < 1) throw new NullReferenceException();

            return Notes.FirstOrDefault(note => note.Id == id);
        }

        public IList<INote> RevealNotes()
        {
            if(null == Notes || Notes.Count < 1) throw new NullReferenceException();

            return Notes;
        }

        public ISubscriber AddSubscriber(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentException("Subscriber emailAddress required.", nameof(emailAddress));
            }

            var subscriber = _subscriberFactory.Create(emailAddress);

            if (null == Subscribers)
                Subscribers = new List<ISubscriber>();
            
            Subscribers.Add(subscriber);

            return subscriber;
        }

        public void RemoveSubscriber(Guid id)
        {
            if(Guid.Empty == id) return;
            if(null == Subscribers ||Subscribers.Count < 1 ) return;

            Subscribers.Remove(Subscribers.FirstOrDefault(subscriber => subscriber.Id == id));
        }
    }
}