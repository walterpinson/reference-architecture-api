using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models
{
    public class MySqlSubscriber
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
    }
}
