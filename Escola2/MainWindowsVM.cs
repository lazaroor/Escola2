using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Escola2
{
    class MainWindowsVM
    {
        public ObservableCollection<Aluno> listaAlunos { get; set; }
        public ICommand AdicionaAluno { get; private set; }
        public ICommand RemoveAluno { get; private set; }
        public ICommand AtualizaAluno { get; private set; }
        public Aluno AlunoSelecionado { get; set; }
        public bool IsValueType { get; }

        EscolaModel db = new EscolaModel();
        public MainWindowsVM()
        {
            listaAlunos = new ObservableCollection<Aluno>() {
                new Aluno()
                {
                    NomeCompleto = "Lazaro Ramos",
                    CodAluno = 3,
                    Serie = (Ano)2
                }
            };
            IniciaComandos();
        }

        public Boolean validateUserEntry(Aluno aluno)
        {
            bool validateSerie = (Ano)aluno.Serie >= (Ano)1 && (Ano)aluno.Serie <= (Ano)11;
            var regexContainInt = new Regex(@"[0-9]+$");
            bool validateName = !regexContainInt.IsMatch(aluno.NomeCompleto);
            if (validateSerie && validateName)
            {
                return true;
            }
            MessageBoxError janelaValidacao = new MessageBoxError();
            janelaValidacao.ShowDialog();
            return false;
        }
        
        public void IniciaComandos()
        {
            AdicionaAluno = new RelayCommand((object _) =>
            {
                Aluno novoAluno = new Aluno();
                TelaApoio janela = new TelaApoio();
                janela.DataContext = novoAluno;
                janela.ShowDialog();
                if(janela.DialogResult == true)
                {
                    if(validateUserEntry(novoAluno)) {
                        listaAlunos.Add(novoAluno);
                        try
                        {
                            db.Database.Connection.Open();
                            Ano serie = novoAluno.Serie;
                            Ano teste = serie;
                            int sql = db.Database.ExecuteSqlCommand($"insert into \"Escola\".aluno (\"nomeCompleto\", serie) VALUES ('Batata', {novoAluno.Serie});");
                            db.Database.Connection.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
               
            });
            RemoveAluno = new RelayCommand((object _) =>
            {
                listaAlunos.Remove(AlunoSelecionado);
            }, (object _) =>
            {
                return AlunoSelecionado != null;
            });
            AtualizaAluno = new RelayCommand((object _) =>
            {
                Aluno alunoAtualizado = new Aluno(AlunoSelecionado.NomeCompleto, AlunoSelecionado.CodAluno, AlunoSelecionado.Serie);
                TelaApoio janela = new TelaApoio();

                janela.DataContext = alunoAtualizado;
                janela.ShowDialog();
               if (janela.DialogResult == true && validateUserEntry(alunoAtualizado))
                    {
                        AlunoSelecionado.NomeCompleto = alunoAtualizado.NomeCompleto;
                        AlunoSelecionado.CodAluno = alunoAtualizado.CodAluno;
                        AlunoSelecionado.Serie= alunoAtualizado.Serie;
                    }
                }, (object _) =>
                {
                    return AlunoSelecionado != null;
            });
        }


    }
}
