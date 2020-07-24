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
    using Microsoft.EntityFrameworkCore;

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
            using (var context = new NoteTakingContext(_connectionString))
            {
                context.Database.EnsureCreated();
                var cat = context.Category.Include(i=>i.Notes).FirstOrDefault(x => x.Id == id);
                return (null == cat) ? null : _mapper.Map<ICategory>(cat);
            }
        }

        public ICategory GetByName(string name)
        {
            using (var context = new NoteTakingContext(_connectionString))
            {
                context.Database.EnsureCreated();
                var cat = context.Category.Include(i=>i.Notes).FirstOrDefault(x => x.Name == name);
                return (null == cat) ? null : _mapper.Map<ICategory>(cat);
            }
        }

        public IList<ICategory> GetAll()
        {
            using (var context = new NoteTakingContext(_connectionString))
            {
                context.Database.EnsureCreated();
                var categories = context.Category.Include(i=>i.Notes).ToList();
                return (null == categories) ? null : _mapper.Map<IList<ICategory>>(categories);
            }
        }

        public ICategory Add(ICategory category)
        {
            using (var context = new NoteTakingContext(_connectionString))
            {
                context.Database.EnsureCreated();
                var mySqlCategory = _mapper.Map<MySqlCategory>(category);
                context.Category.Add(mySqlCategory);
                context.SaveChanges();

                return _mapper.Map<Category>(mySqlCategory);;
            }
        }

        public ICategory Save(ICategory category)
        {
            using (var context = new NoteTakingContext(_connectionString))
            {
                context.Database.EnsureCreated();
                var mySqlCategory = _mapper.Map<MySqlCategory>(category);

                context.Category.Attach(mySqlCategory);

                foreach (var note in mySqlCategory.Notes)
                {
                    if(context.Note.Any(x=>x.Id.Equals(note.Id)))
                        context.Note.Update(note);
                    else
                        context.Note.Add(note);
                }
                context.SaveChanges();

                return category;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new NoteTakingContext(_connectionString))
            {
                context.Database.EnsureCreated();
                var toRemove = context.Category.FirstOrDefault(x=>x.Id == id);
                context.Remove(toRemove);
                context.SaveChanges();
            }
        }
    }
}