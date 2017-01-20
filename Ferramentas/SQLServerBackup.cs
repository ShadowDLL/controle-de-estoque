using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramentas
{
    public class SQLServerBackup
    {
        public static ArrayList ObtemBancoDeDadosSQLServer(String ConnString)
        {
            ArrayList lista = new ArrayList();
            //Criou a conexão
            SqlConnection cn = new SqlConnection(ConnString);
            //Criou o comando
            SqlCommand cm = new SqlCommand("SELECT [name] FROM sysdatabases;", cn);
            //criou o datareader
            SqlDataReader dr;
            try
            {
                cn.Open();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr["name"]);
                }
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
            return lista;
        }
        public static void BackupDatabase(String ConnString, string nomeDB, string backupFile)
        {
            //criou a conexão
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando
            SqlCommand cm = new SqlCommand("BACKUP DATABASE [" + nomeDB + "] TO DISK = '" + backupFile + "'", cn);
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                
                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public static void RestauraDatabase(String ConnString, string nomeDB, string backupFile)
        {
            //criou a conexão
            SqlConnection.ClearAllPools();//Limpa todas as cone~xões do banco
            SqlConnection cn = new SqlConnection(ConnString);
            //criou o comando
            SqlCommand cm = new SqlCommand("[dbo].[spRestoreControleDeEstoque]", cn);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@nomeBanco", nomeDB);
            cm.Parameters.AddWithValue("@caminho", backupFile);
            try
            {
                cn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
