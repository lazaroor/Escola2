using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    internal class Aluno : INotifyPropertyChanged
    {
        private string nomeCompleto;
        private int codAluno;
        private Ano serie;

        public event PropertyChangedEventHandler PropertyChanged;

        public Aluno()
        {
        }

        public Aluno(string nomeCompleto, int codAluno, Ano serie)
        {
            this.nomeCompleto = nomeCompleto;
            this.codAluno = codAluno;
            this.serie = serie;
        }

        //O que falta aqui? gets e setters
        public string NomeCompleto
        {
            get { return nomeCompleto; }
            set { 
                nomeCompleto = value;
                Notifica("NomeCompleto");
              }
        }
        public int CodAluno
        {
            get { return codAluno; }
            set { codAluno = value;
                Notifica("CodAluno");
            }
        }

        public Ano Serie
        {
            get { return serie; }
            set { serie = value;
                Notifica("Serie");
            }
        }

        public void Notifica(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
