using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public class ModelEscola
    {
        public ModelEscola()
        {

        }

        EscolaContext db = new EscolaContext();

        public List<Aluno> GetAlunos()
        {
            return db.Alunos.OrderBy(aluno => aluno.CodAluno).ToList();
        }

        public List<Aluno> CreateAluno(Aluno novoAluno)
        {
            try
            {
                List<Aluno> novoAdicionado = db.Alunos.SqlQuery("insert into \"Escola\".aluno (nomecompleto, serie) VALUES ({0}, {1}) RETURNING *;", novoAluno.NomeCompleto, (int)novoAluno.Serie).ToList();
                return novoAdicionado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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
