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
        private GerenciadorBD db;

        public MainWindowsVM()
        {
            db = new GerenciadorBD(new MyConnection());
            listaAlunos = new ObservableCollection<Aluno>(db.GetAlunos());
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
            MessageBoxError janelaValidacao = new MessageBoxError("Você inseriu algum dado inválido.\n" +
                "Para o campo nome somente é aceito valores sem números.", "Nome inválido");
            
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
                        db.CreateAluno(novoAluno);
                        listaAlunos.Add(novoAluno);
                    }
                }
               
            });
            RemoveAluno = new RelayCommand((object _) =>
            {
                try
                {
                    db.RemoveAluno(AlunoSelecionado.CodAluno);
                    listaAlunos.Remove(AlunoSelecionado);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }, (object _) =>
            {
                return AlunoSelecionado != null;
            });
            AtualizaAluno = new RelayCommand((object _) =>
            {
                Aluno alunoAtualizado = new Aluno(AlunoSelecionado.NomeCompleto, AlunoSelecionado.CodAluno, (Ano)AlunoSelecionado.Serie);
                TelaUpdate janela = new TelaUpdate();
                janela.DataContext = alunoAtualizado;
                janela.ShowDialog();
               if (janela.DialogResult == true && validateUserEntry(alunoAtualizado))
                {
                    try
                    {
                        db.UpdateAluno(alunoAtualizado.NomeCompleto, alunoAtualizado.Serie, alunoAtualizado.CodAluno);
                        AlunoSelecionado.NomeCompleto = alunoAtualizado.NomeCompleto;
                        AlunoSelecionado.CodAluno = alunoAtualizado.CodAluno;
                        AlunoSelecionado.Serie= alunoAtualizado.Serie;
                    } 
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                }, (object _) =>
                {
                    return AlunoSelecionado != null;
            });
        }


    }
}
