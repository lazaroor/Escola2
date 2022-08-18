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
        public GerenciadorBD(IDb db)
        {
            this.db = db;
        }

        public List<Aluno> GetAlunos()
        {
            return db.GetAlunos();
        }

        public void CreateAluno(Aluno novoALuno)
        {
            try
            {
                db.CreateAluno(novoALuno);
            } catch (Exception ex)
            {
                MessageBoxError janelaValidacao = new MessageBoxError("Opaaaa", "Banco fora do ar");
                janelaValidacao.ShowDialog();
            }
        }

        public int RemoveAluno(int codAluno)
        {
            return db.RemoveAluno(codAluno);
        }

        public int UpdateAluno(string nomeAluno, Ano serieAluno, int codAluno)
        {
            return db.UpdateAluno(nomeAluno, serieAluno, codAluno);
        }

        public Aluno CapturaAlunoPorCodigo(int codAluno)
        {
            return db.CapturaAlunoPorCodigo(codAluno);
        }
    }
}
