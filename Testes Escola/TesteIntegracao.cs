using Escola2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_Escola
{
    internal class TesteIntegracao
    {
        private GerenciadorBD db;
        public List<Aluno> listaAlunos { get; set; }
        [SetUp]
        public void SetupInserir()
        {
            db = new GerenciadorBD("mysql");
            listaAlunos = new List<Aluno>();
        }

        [Test]
        public void TesteInserirBD()
        {
            Aluno novoAluno = new Aluno() { 
                NomeCompleto = "tests", 
                Serie = (Ano)3
            };
            Assert.Zero(novoAluno.CodAluno);
            db.CreateAluno(novoAluno);
            Assert.NotZero(novoAluno.CodAluno);
            db.RemoveAluno(novoAluno.CodAluno);
        }

        [Test]
        public void TesteListarBD()
        {
            Assert.Zero(listaAlunos.Count);
            listaAlunos = db.GetAlunos();
            Assert.NotZero(listaAlunos.Count);
            Aluno teste = db.CapturaAlunoPorCodigo(2);
            //Assert.That(listaAlunos[0].GetType(), Is.SameAs(typeof(Aluno)));
            Assert.IsInstanceOf<Aluno>(listaAlunos[0]);
        }
    }
}
