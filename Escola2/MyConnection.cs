using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public class MyConnection : IDb
    {
        private MySqlConnection mConn;
        private MySqlCommand mySqlCommand;
        public MyConnection()
        {
            mConn = new MySqlConnection("Persist Security Info=False; server=localhost;port=3307;database=sys;uid=root;server=localhost;database=sys;uid=root;pwd=123");
            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mConn;
        }

        public List<Aluno> CreateAluno(Aluno novoAluno)
        {
            try
            {
                mConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
        }

        public List<Aluno> GetAlunos()
        {
            mySqlCommand.CommandText = "SELECT * FROM sys.aluno";
            try
            {
                mConn.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            } 
            finally
            {
                mConn.Close();
            }
        }

        public int RemoveAluno(int codAluno)
        {
            try
            {
                mConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
            throw new NotImplementedException();
        }

        public int UpdateAluno(string nomeAluno, Ano serieAluno, int codAluno)
        {
            try
            {
                mConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
            throw new NotImplementedException();
        }
    }
}
