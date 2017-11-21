namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface INoteTaker
    {
        NoteDto TakeNote(NewNoteMessage newNoteMessage);
        NoteDto TakeCategorizedNote(Guid categoryId, NewNoteMessage newNoteMessage);
        IList<NoteDto> ReadCategorizedNotes(Guid categoryId);
        NoteDto ReadCategorizedNote(Guid categoryId, Guid noteId);
    }
}