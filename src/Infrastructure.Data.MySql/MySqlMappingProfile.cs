using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
using CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models;

namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb
{
    public class MySqlMappingProfile : Profile
    {
        public MySqlMappingProfile()
        {
            CreateMap<INote, MySqlNote>().ReverseMap();
            CreateMap<ISubscriber, MySqlSubscriber>().ReverseMap();

            CreateMap<ICategory, MySqlCategory>()
            .ReverseMap().ConstructUsing(x => new Category() { Name = x.Name, Id=x.Id, Created = x.Created }); 
            //TODO Above is the problematic line with automapper. Mapping Notes = x.Notes
        }
    }
}
