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
            CreateMap<Category, MySqlCategory>().ReverseMap();
        }
    }
}
