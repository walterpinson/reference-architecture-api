namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;

    public class NoteTaker : INoteTaker
    {
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