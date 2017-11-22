namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface INoteTaker
    {
        // Work with notes with regard for categories.
        // In esseence these notes will be stored in the context of default category.
        NoteDto TakeNote(NewNoteMessage newNoteMessage);
        void DeleteNote(Guid noteId);
        IList<NoteDto> ListNotes();

        // Work with categories
        IList<CategoryDto> ListCategories();
        CategoryDto CreateNewCategory(NewCategoryMessage newCategoryMessage);
        CategoryDto RenameCategory(Guid categoryId, string newCategoryName);
        CategoryDto GetCategoryDetail(Guid categoryId);

        // Work with categorized notes
        CategoryDto TakeCategorizedNote(Guid categoryId, NewNoteMessage newNoteMessage);
        CategoryDto RemoveCategorizedNote(Guid categoryId, Guid noteId);
    }
}