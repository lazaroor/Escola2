using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    //pgContext
    public class pgContext:DbContext
    {
        public pgContext() : base("postgres") { }
        // public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Aluno> Alunos { get; set; }
    }
}
