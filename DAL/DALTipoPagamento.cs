using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALTipoPagamento
    {
        private DALConexao conexao;
        public DALTipoPagamento(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Inserir(ModeloTipoPagamento modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spTipoPagamentoInserir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tpa_nome", modelo.tpa_nome);
                conexao.Conectar();
                modelo.tpa_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloTipoPagamento modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spTipoPagamentoAlterar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tpa_cod", modelo.tpa_cod);
                cmd.Parameters.AddWithValue("@tpa_nome", modelo.tpa_nome);
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
                SqlCommand cmd = new SqlCommand("[dbo].[spTipoPagamentoExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tpa_cod", cod);
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
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spTipoPagamentoConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@tpa_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloTipoPagamento CarregaModeloTipoPagamento(int cod)
        {
            try
            {
                ModeloTipoPagamento modelo = new ModeloTipoPagamento();
                SqlCommand cmd = new SqlCommand("[dbo].[spTipoPagamentoConsultarCodigo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tpa_cod", cod);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.tpa_cod = Convert.ToInt32(registro["CODIGO"]);
                    modelo.tpa_nome = registro["NOME"].ToString();
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
    }
}
