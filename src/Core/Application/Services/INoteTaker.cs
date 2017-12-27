namespace CompanyName.Notebook.NoteTaking.Core.Application.Services
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;

    public interface INoteTaker
    {
        // Work with notes with regard for categories.
        // In esseence these notes will be stored in the context of default category.
        NoteDto TakeNote(SecurityContext securityContext, NewNoteMessage newNoteMessage);
        NoteDto ReadNote(SecurityContext securityContext, Guid noteId);
        void RemoveNote(SecurityContext securityContext, Guid noteId);
        IList<NoteDto> ListNotes(SecurityContext securityContext);

        // Work with categories
        IList<CategoryDto> ListCategories(SecurityContext securityContext);
        CategoryDto CreateNewCategory(SecurityContext securityContext, NewCategoryMessage newCategoryMessage);
        CategoryDto RenameCategory(SecurityContext securityContext, Guid categoryId, string newCategoryName);
        CategoryDto GetCategoryDetail(SecurityContext securityContext, Guid categoryId);
        void RemoveCategory(SecurityContext securityContext, Guid categoryId);

        // Work with categorized notes
        NoteDto TakeCategorizedNote(SecurityContext securityContext, Guid categoryId, NewNoteMessage newNoteMessage);
        CategoryDto RemoveCategorizedNote(SecurityContext securityContext, Guid categoryId, Guid noteId);
        IList<NoteDto> ListCategorizedNotes(SecurityContext securityContext, Guid categoryId);
        NoteDto ReadCategorizedNote(SecurityContext securityContext, Guid categoryId, Guid noteId);
    }
}