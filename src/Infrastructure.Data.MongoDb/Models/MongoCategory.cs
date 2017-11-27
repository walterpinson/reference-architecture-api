namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MongoDb.Models
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
    using MongoRepository.NetCore;

    [CollectionName("Categories")]
    public class MongoCategory : Category, IEntity<Guid>
    {
    }
}