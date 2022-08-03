using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public class EscolaContext:DbContext
    {
        public EscolaContext() : base("postgres") { }
        // public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Aluno> Alunos { get; set; }

    }
}
