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
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sys.aluno", mConn);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        Console.WriteLine(mySqlDataReader["0"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
            throw new Exception();
        }

        public List<Aluno> GetAlunos()
        {
            try
            {
                mConn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sys.aluno", mConn);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    // Cada linha da tabela retorna um array onde cada coluna é um índice desse array, no caso da tabela aluno o array vai de 0 a 2 
                    // (int)mySqlDataReader[0], mySqlDataReader[1].ToString(), (Ano)(int)mySqlDataReader[2].ToString()
                    Console.WriteLine(mySqlDataReader["codaluno"].ToString(), mySqlDataReader["nomecompleto"].ToString(), mySqlDataReader["serie"].ToString());
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mConn.Close();
            }
            throw new Exception();
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
