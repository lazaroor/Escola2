using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    // pgConnection
    public class pgConnection : IDb
    {
        private pgContext db;
        public pgConnection()
        {
            db = new pgContext();
        }      

        public List<Aluno> GetAlunos()
        {
            return db.Alunos.OrderBy(aluno => aluno.CodAluno).ToList();
        }

        public void CreateAluno(Aluno novoAluno)
        {
            try
            {
                List<Aluno> novoAdicionado = db.Alunos.SqlQuery("insert into \"Escola\".aluno (nomeCompleto, serie) VALUES ({0}, {1}) RETURNING *;", novoAluno.NomeCompleto, (int)novoAluno.Serie).ToList();
                novoAluno.CodAluno = novoAdicionado[0].CodAluno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public int RemoveAluno(int codAluno)
        {
            return db.Database.ExecuteSqlCommand("DELETE FROM \"Escola\".aluno WHERE codaluno = {0}", codAluno);
        }

        public int UpdateAluno(string nomeAluno, Ano serieAluno, int codAluno)
        {
            return db.Database.ExecuteSqlCommand("UPDATE \"Escola\".aluno SET nomecompleto = {0}, serie = {1} WHERE codaluno ={2}",
                           nomeAluno, (int)serieAluno, codAluno);
        }
    }
}
