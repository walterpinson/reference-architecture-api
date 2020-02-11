namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using MySql.Data.MySqlClient;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.EF;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        public string _connectionString { get; set; }

        public CategoryRepository(string connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }

        public ICategory Get(Guid id)
        {
            using (var context = new NoteTakingContext())
            {
                context.Database.EnsureCreated();
                var cat = context.Category.FirstOrDefault(x => x.Id == id);
                return (null == cat) ? null : _mapper.Map<ICategory>(cat);
            }
        }

        public ICategory GetByName(string name)
        {
            using (var context = new NoteTakingContext())
            {
                context.Database.EnsureCreated();
                var cat = context.Category.FirstOrDefault(x => x.Name == name);
                return (null == cat) ? null : _mapper.Map<ICategory>(cat);
            }

        }

        public IList<ICategory> GetAll()
        {
            using (var context = new NoteTakingContext())
            {
                context.Database.EnsureCreated();
                var categories = context.Category;
                return (null == categories) ? null : _mapper.Map<IList<ICategory>>(categories);
            }
        }

        public ICategory Add(ICategory category)
        {
            using (var context = new NoteTakingContext())
            {
                context.Database.EnsureCreated();
                var mySqlCategory = _mapper.Map<MySqlCategory>(category);
                context.Category.Add(mySqlCategory);
                context.SaveChanges();

                return category;
            }
        }

        public ICategory Save(ICategory category)
        {
            using (var context = new NoteTakingContext())
            {
                context.Database.EnsureCreated();
                var mySqlCategory = _mapper.Map<MySqlCategory>(category);
                context.Category.Update(mySqlCategory);
                context.SaveChanges();

                return category;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new NoteTakingContext())
            {
                context.Database.EnsureCreated();
                var toRemove = context.Category.FirstOrDefault(x=>x.Id == id);
                context.Remove(toRemove);
                context.SaveChanges();
            }
        }
    }
}