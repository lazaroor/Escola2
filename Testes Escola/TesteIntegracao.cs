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
        [SetUp]
        public void Setup()
        {
            db = new GerenciadorBD("mysql");
        }

        [Test]
        public void TesteInserirBD()
        {
            Aluno novoAluno = new Aluno() { 
                NomeCompleto = "_tests", 
                Serie = (Ano)3
            };
            Assert.Zero(novoAluno.CodAluno);
            db.CreateAluno(novoAluno);
            Assert.NotZero(novoAluno.CodAluno);

        }
    }
}
