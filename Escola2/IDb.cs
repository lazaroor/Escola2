using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public interface IDb
    {
        List<Aluno> GetAlunos();
        List<Aluno> CreateAluno(Aluno novoAluno);
        int RemoveAluno(int codAluno);
        int UpdateAluno(string nomeAluno, Ano serieAluno, int codAluno);

    }
}
