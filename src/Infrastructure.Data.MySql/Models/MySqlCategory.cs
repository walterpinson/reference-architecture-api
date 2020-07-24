namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models
{
    using System;
    using System.Collections.Generic;

    public class MySqlCategory
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public virtual IList<MySqlNote> Notes { get; set; }
        public virtual IList<MySqlSubscriber> Subscribers { get; set; }

        public MySqlCategory()
        {
            Notes = new List<MySqlNote>();
            Subscribers = new List<MySqlSubscriber>();
        }
    }
}