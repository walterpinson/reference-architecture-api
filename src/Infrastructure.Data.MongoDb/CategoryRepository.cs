namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb.Models;
    using MongoRepository.NetCore;

    public class CategoryRepository : MongoRepository<MongoCategory, Guid>, ICategoryRepository
    {
        public ICategory Add(ICategory category)
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

        public ICategory Save(ICategory category)
        {
            throw new NotImplementedException();
        }
    }
}