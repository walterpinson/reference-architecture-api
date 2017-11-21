namespace CompanyName.Notebook.NoteTaking.Core.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class Category : ICategory
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Created { get; protected set; }
        public IList<INote> Notes { get; protected set; }
        public IList<ISubscriber> Subscribers { get; protected set; }

        public Category()
        {
        }

        public Category(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("New Note must have name.", nameof(name));
            }

            Created = DateTime.UtcNow;
            Name = name;
        }

        public INote AddNote(string text)
        {
            throw new NotImplementedException();
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