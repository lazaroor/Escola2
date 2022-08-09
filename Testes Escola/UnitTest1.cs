using Escola2;
using System.Collections.ObjectModel;

namespace Testes_Escola
{
    public class Tests
    {
        public ObservableCollection<Aluno> listaAlunos { get; set; }
        [SetUp]
        public void Setup()
        {
            listaAlunos = new ObservableCollection<Aluno>();
        }

        [Test]
        public void Test1()
        {
            listaAlunos.Add(new Aluno());
            Assert.That(listaAlunos.Count, Is.EqualTo(1));
        }
    }
}