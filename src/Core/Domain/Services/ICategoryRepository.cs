namespace CompanyName.Notebook.NoteTaking.Core.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public interface ICategoryRepository
    {
        ICategory Get(Guid id);
        ICategory GetByName(string name);
        IList<ICategory> GetAll();
        ICategory Add<ICategory>(ICategory category);
        ICategory Save<ICategory>(ICategory category);
        ICategory Delete(Guid id);
    }
}