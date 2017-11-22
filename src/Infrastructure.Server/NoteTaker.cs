namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Application.Exceptions;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;

    public class NoteTaker : INoteTaker
    {
        private readonly INoteFactory _noteFactory;
        private readonly ISubscriberFactory _subscriberFactory;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public NoteTaker(
            INoteFactory noteFactory,
            ISubscriberFactory subscriberFactory,
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
            _noteFactory = noteFactory ?? throw new ArgumentNullException(nameof(noteFactory));
            _subscriberFactory = subscriberFactory ?? throw new ArgumentNullException(nameof(subscriberFactory));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public NoteDto ReadCategorizedNote(Guid categoryId, Guid noteId)
        {
            var category = _categoryRepository.Get(categoryId);
            if (null == category) throw new NoteTakerException("Category note found.");

            var note = category.RevealNote(noteId);
            if (null == note) throw new NoteTakerException("Note not found.");

            return _mapper.Map<NoteDto>(note);
        }

        public IList<NoteDto> ReadCategorizedNotes(Guid categoryId)
        {
            var category = _categoryRepository.Get(categoryId);
            if (null == category) throw new NoteTakerException("Category note found.");

            return _mapper.Map<IList<NoteDto>>(category.Notes);
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