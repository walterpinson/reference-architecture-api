namespace CompanyName.Notebook.NoteTaking.Core.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public interface ICategoryRepository
    {
        ICategory Get(Guid id);
        IList<ICategory> Get(string userId);
        ICategory Add<ICategory>(ICategory category);
        ICategory Save<ICategory>(ICategory order);
        ICategory Delete(Guid id);
    }
}