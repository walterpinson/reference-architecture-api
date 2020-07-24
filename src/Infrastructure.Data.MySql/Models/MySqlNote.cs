using CompanyName.Notebook.NoteTaking.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyName.Notebook.NoteTaking.Infrastructure.Data.MySqlDb.Models
{
    public class MySqlNote : INote
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
    }
}
