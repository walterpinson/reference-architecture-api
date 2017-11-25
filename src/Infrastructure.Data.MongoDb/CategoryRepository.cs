namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;

    public class CategoryRepository : ICategoryRepository
    {
        public ICategory Add<ICategory>(ICategory category)
        {
            throw new NotImplementedException();
        }

        public ICategory Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICategory Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<ICategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICategory GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public ICategory Save<ICategory>(ICategory category)
        {
            throw new NotImplementedException();
        }
    }
}