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
    public class DALCliente
    {
        private DALConexao conexao;
        public DALCliente(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ParametrosCliente(ModeloCliente modelo, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@cli_tipo", modelo.cli_tipo);
            cmd.Parameters.AddWithValue("@cli_nome", modelo.cli_nome);
            cmd.Parameters.AddWithValue("@cli_rsocial", modelo.cli_rsocial);
            cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.cli_cpfcnpj);
            cmd.Parameters.AddWithValue("@cli_rgie", modelo.cli_rgie);
            cmd.Parameters.AddWithValue("@cli_cep", modelo.cli_cep);
            cmd.Parameters.AddWithValue("@est_sgl", modelo.cli_sgl);
            cmd.Parameters.AddWithValue("@est_nome", modelo.cli_estado);
            cmd.Parameters.AddWithValue("@cli_cidade", modelo.cli_cidade);
            cmd.Parameters.AddWithValue("@cli_bairro", modelo.cli_bairro);
            cmd.Parameters.AddWithValue("@cli_logradouro", modelo.cli_logradouro);
            cmd.Parameters.AddWithValue("@cli_numero", modelo.cli_numero);
            cmd.Parameters.AddWithValue("@end_complemento", modelo.cli_complemento);
            cmd.Parameters.AddWithValue("@cli_email", modelo.cli_email);
            cmd.Parameters.AddWithValue("@cli_telefone", modelo.cli_telefone);
            cmd.Parameters.AddWithValue("@cli_celular", modelo.cli_celular);
        }
        public void Inserir(ModeloCliente modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spClienteInserir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                ParametrosCliente(modelo, cmd);
                conexao.Conectar();
                modelo.cli_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloCliente modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spClienteAlterar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cli_cod", modelo.cli_cod);
                ParametrosCliente(modelo, cmd);
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
                SqlCommand cmd = new SqlCommand("[dbo].[spClienteExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cli_cod", cod);
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
        public DataTable LocalizarNome(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spClienteLocalizarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cli_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloCliente CarregaModeloCliente(int cod)
        {
            try
            {
                ModeloCliente modelo = new ModeloCliente();
                SqlCommand cmd = new SqlCommand("[dbo].[spClienteLocalizarCodigo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cli_cod", cod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.cli_cod = Convert.ToInt32(dr["CODIGO"]);
                    modelo.cli_nome = dr["NOME"].ToString();
                    modelo.cli_cpfcnpj = dr["CPFCNPJ"].ToString();
                    modelo.cli_rgie = dr["RGIE"].ToString();
                    modelo.cli_rsocial = dr["RSOCIAL"].ToString();
                    modelo.cli_tipo = dr["TIPO"].ToString();
                    modelo.cli_cep = dr["CEP"].ToString();
                    modelo.cli_estado = dr["ESTADO"].ToString();
                    modelo.cli_sgl = dr["SIGLA"].ToString();
                    modelo.cli_cidade = dr["CIDADE"].ToString();
                    modelo.cli_bairro = dr["BAIRRO"].ToString();
                    modelo.cli_logradouro = dr["LOGRADOURO"].ToString();
                    modelo.cli_numero = dr["NUMERO"].ToString();
                    modelo.cli_complemento = dr["COMPLEMENTO"].ToString();
                    modelo.cli_email = dr["EMAIL"].ToString();
                    modelo.cli_telefone = dr["TELEFONE"].ToString();
                    modelo.cli_celular = dr["CELULAR"].ToString();
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
