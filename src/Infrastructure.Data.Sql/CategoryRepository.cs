namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.Sql
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
                Notes = category.Notes,
                Subscribers = category.Subscribers
            };
            Console.WriteLine($"Mock CategoryRepository.Add():\n{newCategory}");
            return newCategory;
        }

        public void Delete(Guid id)
        {
            Console.WriteLine($"Mock CategoryRepository.Delete({id}).");
        }

        public ICategory Get(Guid id)
        {
            var category = new Category()
            {
                Id = id,
                Name = "1 Ton Trucks",
                Created = DateTime.UtcNow,
                Notes = null,
                Subscribers = null
            };
            Console.WriteLine($"Mock CategoryRepository.Get({id}):\n{category}");
            return category;
        }

        public IList<ICategory> GetAll()
        {
            var categories = new List<ICategory>();
            categories.Add(new Category()
            {
                Id = Guid.NewGuid(),
                Name = "1 Ton Trucks",
                Created = DateTime.UtcNow,
                Notes = null,
                Subscribers = null
            });
            categories.Add(new Category()
            {
                Id = Guid.NewGuid(),
                Name = "SUVs",
                Created = DateTime.UtcNow,
                Notes = null,
                Subscribers = null
            });
            categories.Add(new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Convertibles",
                Created = DateTime.UtcNow,
                Notes = null,
                Subscribers = null
            });

            Console.WriteLine($"Mock CategoryRepository.GetAll():\n{categories}");
            return categories;
        }

        public ICategory GetByName(string name)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Created = DateTime.UtcNow,
                Notes = null,
                Subscribers = null
            };
            Console.WriteLine($"Mock CategoryRepository.GetByName({name}):\n{category}");
            return category;
        }

        public ICategory Save(ICategory category)
        {
            Console.WriteLine($"Mock CategoryRepository.Save():\n{category}");
            return category;
        }
    }
}