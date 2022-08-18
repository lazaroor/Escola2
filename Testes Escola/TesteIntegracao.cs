using Escola2;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes_Escola
{
    internal class TesteIntegracao
    {
        private MySqlConnection mConn;
        private MySqlCommand mySqlCommand;
        private GerenciadorBD db;
        public List<Aluno> listaAlunos { get; set; }
        [SetUp]
        public void SetupInserir()
        {
            db = new GerenciadorBD(new MyConnection());
            listaAlunos = new List<Aluno>();
            mConn = new MySqlConnection("Persist Security Info=False; server=localhost;port=3307;database=sys;uid=root;server=localhost;database=sys;uid=root;pwd=123");
            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mConn;
        }

        [Test]
        public void TesteInserirBD()
        {
            Aluno novoAluno = new Aluno() { 
                NomeCompleto = "tests", 
                Serie = (Ano)3
            };
            Assert.Zero(novoAluno.CodAluno);
            // mConn.Open();
            // mySqlCommand.CommandText = $"INSERT INTO sys.aluno SET nomecompleto = \"{novoAluno.NomeCompleto}\", serie = {(int)novoAluno.Serie};";
            //mySqlCommand.ExecuteNonQuery();
            //novoAluno.CodAluno = (int)mySqlCommand.LastInsertedId;
            db.CreateAluno(novoAluno);
            Assert.NotZero(novoAluno.CodAluno);
        }

        [Test]
        public void TesteListarBD()
        {
            Assert.Zero(listaAlunos.Count);
            listaAlunos = db.GetAlunos();
            Assert.NotZero(listaAlunos.Count);
            //Aluno teste = db.CapturaAlunoPorCodigo(2);
            //Assert.That(listaAlunos[0].GetType(), Is.SameAs(typeof(Aluno)));
            Assert.IsInstanceOf<Aluno>(listaAlunos[0]);
        }

        [Test]
        public void TesteDeletarBD()
        {
            Aluno teste = db.CapturaAlunoPorCodigo(9);
            Assert.IsInstanceOf<Aluno>(teste);
            db.RemoveAluno(9);
            Aluno testezada2 = db.CapturaAlunoPorCodigo(9);
            Assert.IsNull(testezada2);
        }
    }
}
