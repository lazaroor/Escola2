using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    [Table("aluno", Schema = "Escola")]
    public class Aluno : INotifyPropertyChanged, INotifyCollectionChanged
    {
        private int codAluno;
        private string nomeCompleto;
        private Ano serie;

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Aluno(){ }

        public Aluno(string nomecompleto, int codaluno, Ano serie)
        {
            this.codAluno = codaluno;
            this.nomeCompleto = nomecompleto;
            this.serie = serie;
        }
        [Key(), Column("codaluno")]
        public int CodAluno
        {
            get { return codAluno; }
            set { codAluno = value;
                Notifica("CodAluno");
            }
        }
        [Column("nomecompleto")]
        public string NomeCompleto
        {
            get { return nomeCompleto; }
            set { 
                nomeCompleto = value;
                Notifica("NomeCompleto");
              }
        }
        [Column("serie")]
        public Ano Serie
        {
            get { return serie; }
            set { serie = value;
                Notifica("Serie");
            }
        }

        public List<Aluno> Todos()
        {
            var db = new pgContext();
            return db.Alunos.ToList();
        }

        public void Notifica(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            if(CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

    }

}
