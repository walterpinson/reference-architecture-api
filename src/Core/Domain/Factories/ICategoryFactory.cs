namespace CompanyName.Notebook.NoteTaking.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public interface ICategoryFactory
    {
        ICategory Create(
            string name,
            INoteFactory noteFactory,
            ISubscriberFactory subscriberFactory
        );

        ICategory Build(
            ICategory category,
            INoteFactory noteFactory,
            ISubscriberFactory subscriberFactory
        );
    }
}