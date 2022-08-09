using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public class GerenciadorBD
    {

        private IDb db;
        public GerenciadorBD(string nomeDb)
        {
            if(nomeDb == "postgres")
            {
                db = new pgConnection();
            } else if (nomeDb == "mysql")
            {
                db = new MyConnection();
            }
            else
            {
                db = null;
            }
        }

        public List<Aluno> GetAlunos()
        {
            return db.GetAlunos();
        }

        public void CreateAluno(Aluno novoALuno)
        {
            db.CreateAluno(novoALuno);
        }

        public int RemoveAluno(int codAluno)
        {
            return db.RemoveAluno(codAluno);
        }

        public int UpdateAluno(string nomeAluno, Ano serieAluno, int codAluno)
        {
            return db.UpdateAluno(nomeAluno, serieAluno, codAluno);
        }
    }
}
