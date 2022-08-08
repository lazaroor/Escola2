﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public class MyConnection : IDb
    {
        public List<Aluno> listaAlunos { get; set; }
        Aluno aluno { get; set; }
        private MySqlConnection mConn;
        private MySqlCommand mySqlCommand;
        private int lastId;
        public MyConnection()
        {
            mConn = new MySqlConnection("Persist Security Info=False; server=localhost;port=3307;database=sys;uid=root;server=localhost;database=sys;uid=root;pwd=123");
            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mConn;
            lastId = 0;
        }

        public List<Aluno> CreateAluno(Aluno novoAluno)
        {
            try
            {
                mConn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mConn;
                mySqlCommand.CommandText = $"INSERT INTO sys.aluno SET nomecompleto = \"{novoAluno.NomeCompleto}\", serie = {(int)novoAluno.Serie};";
                mySqlCommand.ExecuteNonQuery();
                List<Aluno> listaAluno = new List<Aluno>();
                aluno = new Aluno(novoAluno.NomeCompleto, (int)mySqlCommand.LastInsertedId, novoAluno.Serie);
                listaAluno.Add(aluno);
                return listaAluno;
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
            try
            {
                mConn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM sys.aluno", mConn);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                listaAlunos = new List<Aluno>();
                while (mySqlDataReader.Read())
                {
                    aluno = new Aluno(mySqlDataReader["nomecompleto"].ToString(), (int)mySqlDataReader["codaluno"], (Ano)(int)mySqlDataReader["serie"]);
                    listaAlunos.Add(aluno);
                }
                return listaAlunos;
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

        public int RemoveAluno(int codAluno)
        {
            try
            {
                mConn.Open();
                string query = $"DELETE FROM sys.aluno WHERE codaluno = {codAluno}";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mConn);
                mySqlCommand.ExecuteNonQuery();
                return 1;
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

        public int UpdateAluno(string nomeAluno, Ano serieAluno, int codAluno)
        {
            try
            {
                mConn.Open();
                // string query = String.Format("UPDATE sys.aluno SET nomecompleto = {0}, serie = {1} WHERE codaluno = {2}", nomeAluno, serieAluno, codAluno);
                string query = $"UPDATE sys.aluno SET nomecompleto = \"{ nomeAluno }\", serie = { (int)serieAluno } WHERE codaluno = { codAluno }; ";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mConn);
                mySqlCommand.ExecuteNonQuery();
                return 1;
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