namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;

    public class NoteTaker : INoteTaker
    {
        private readonly INoteFactory _noteFactory;
        private readonly ISubscriberFactory _subscriberFactory;
        private readonly ICategoryRepository _categoryRepository;

        public NoteTaker(
            INoteFactory noteFactory,
            ISubscriberFactory subscriberFactory,
            ICategoryRepository categoryRepository
        )
        {
            _noteFactory = noteFactory ?? throw new ArgumentNullException(nameof(noteFactory));
            _subscriberFactory = subscriberFactory ?? throw new ArgumentNullException(nameof(subscriberFactory));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
        
        public NoteDto ReadCategorizedNote(Guid categoryId, Guid noteId)
        {
            throw new NotImplementedException();
        }

        public IList<NoteDto> ReadCategorizedNotes(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public NoteDto TakeCategorizedNote(Guid categoryId, NewNoteMessage newNoteMessage)
        {
            throw new NotImplementedException();
        }

        public NoteDto TakeNote(NewNoteMessage newNoteMessage)
        {
            throw new NotImplementedException();
        }
    }
}