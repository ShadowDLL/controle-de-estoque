using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUnidadeMedida
    {
        private DALConexao conexao;
        public DALUnidadeMedida(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloUnidadeMedida modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUndMedidaInserir]", conexao._conexao);
                //cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@umed_nome", modelo.umed_nome);
                conexao.Conectar();
                modelo.umed_cod = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void Alterar(ModeloUnidadeMedida modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUndMedidaAlterar]", conexao._conexao);
                //cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@umed_cod", modelo.umed_cod);
                cmd.Parameters.AddWithValue("@umed_nome", modelo.umed_nome);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void Excluir(int cod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUndMedidaExcluir]", conexao._conexao);
                //cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@umed_cod", cod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[spUndMedidaConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@umed_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloUnidadeMedida CarregaUnidadeMedida(int codigo)
        {
            try
            {
                ModeloUnidadeMedida modelo = new ModeloUnidadeMedida();
                SqlCommand cmd = new SqlCommand("[dbo].[spUndMedidaConsultarCodigo]", conexao._conexao);
                //cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@umed_cod", codigo);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.umed_cod = Convert.ToInt32(registro["CODIGO"]);
                    modelo.umed_nome = registro["NOME"].ToString();
                }
                return modelo;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public int VerificaUnidadeMedida(string valor)
        {
            try
            {
                int r = 0;
                SqlCommand cmd = new SqlCommand("[dbo].[spVerificaUnidadeMedida]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@umed_nome", valor);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    r = 1;
                }
                return r;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
