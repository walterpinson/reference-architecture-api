namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb
{
    using System;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb.Models;

    public class MongoMappingProfile : Profile
    {
        public MongoMappingProfile()
        {
            CreateMap<Category, MongoCategory>().ReverseMap();
        }
    }
}