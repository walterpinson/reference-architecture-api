namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface INoteTaker
    {
        NoteDto AddNote(NewNoteMessage newNoteMessage);
        NoteDto AddNoteToCategory(Guid categoryId, NewNoteMessage newNoteMessage);
        IList<NoteDto> ReadCategory(Guid categoryId);
        NoteDto ReadNote(Guid noteId);
    }
}