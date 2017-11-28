namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
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