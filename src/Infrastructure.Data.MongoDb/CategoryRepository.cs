namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;

    public class CategoryRepository : ICategoryRepository
    {
        public ICategory Add(ICategory category)
        {
            var newCategory = new Category()
            {
                Id = Guid.NewGuid(),
                Name = category.Name,
                Created = category.Created,
                Notes = new List<INote>(category.Notes),
                Subscribers = new List<ISubscriber>(category.Subscribers)
            };
            Console.WriteLine($"Add new Category\n${newCategory}");
            return newCategory;
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

        public ICategory Save(ICategory category)
        {
            throw new NotImplementedException();
        }
    }
}