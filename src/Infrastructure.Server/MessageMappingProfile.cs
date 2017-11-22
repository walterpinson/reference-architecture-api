namespace CompanyName.Notebook.NoteTaking.Infrastructure.Server
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public class MessageMappingProfile: Profile
    {
        public MessageMappingProfile()
        {
            // Map application messages to domain models
            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<Subscriber, SubscriberDto>().ReverseMap();
        }
    }
}