namespace CompanyName.Notebook.NoteTaking.Core.Domain.Factories
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Models;

    public class CategoryFactory : ICategoryFactory
    {
        public ICategory Build(ICategory category, INoteFactory noteFactory, ISubscriberFactory subscriberFactory)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            if (noteFactory == null) throw new ArgumentNullException(nameof(noteFactory));
            if (subscriberFactory == null) throw new ArgumentNullException(nameof(subscriberFactory));

            return new Category(
                category.Name, 
                noteFactory,
                subscriberFactory
            );
        }

        public ICategory Create(
            string name, 
            INoteFactory noteFactory,
            ISubscriberFactory subscriberFactory
        )
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Invalid argument", nameof(name));
            if (noteFactory == null) throw new ArgumentNullException(nameof(noteFactory));
            if (subscriberFactory == null) throw new ArgumentNullException(nameof(subscriberFactory));

            return new Category(
                name, 
                noteFactory,
                subscriberFactory
            );
        }
    }
}