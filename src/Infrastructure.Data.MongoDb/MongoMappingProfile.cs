namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb.Models;
    using MongoDB.Bson.Serialization;

    public class MongoMappingProfile : Profile
    {
        public MongoMappingProfile()
        {
            CreateMap<Category, MongoCategory>().ReverseMap();
            
            BsonClassMap.RegisterClassMap<Note>();
        }
    }
}