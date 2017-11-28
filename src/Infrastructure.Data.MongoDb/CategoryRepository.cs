namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb.Models;
    using MongoDB.Driver;
    using MongoRepository.NetCore;

    public class CategoryRepository : MongoRepository<MongoCategory, Guid>, ICategoryRepository
    {
        private readonly IMapper _mapper;

        public CategoryRepository(MongoUrl mongoUrl, IMapper mapper)
            : base(mongoUrl) => _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public CategoryRepository(string connectionString, IMapper mapper)
            : base(connectionString) => _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public ICategory Add(ICategory category)
        {
            var mongoCategory = _mapper.Map<MongoCategory>(category);
            var outCategory = _mapper.Map<ICategory>(base.Add(mongoCategory));

            return outCategory;
        }

        public ICategory Get(Guid id)
        {
            var mongoCategory = this.GetById(id);
            return (null == mongoCategory) ? null : _mapper.Map<ICategory>(mongoCategory);
        }

        public IList<ICategory> GetAll()
        {
            var mongoCategories = this.collection.AsQueryable().ToList();
            return (null == mongoCategories) ? null : _mapper.Map<IList<ICategory>>(mongoCategories);
        }

        public ICategory GetByName(string name)
        {
            var mongoCategory = this.collection.Find(m => m.Name == name).First();
            return (null == mongoCategory) ? null : _mapper.Map<ICategory>(mongoCategory);
        }

        public ICategory Save(ICategory category)
        {
            var mongoCategory = _mapper.Map<MongoCategory>(category);
            var outCategory = _mapper.Map<ICategory>(base.Update(mongoCategory));

            return outCategory;
        }
    }
}