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
    public class DALFornecedor
    {
        private DALConexao conexao;
        public DALFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ParametrosFornecedor(ModeloFornecedor modelo, SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@for_nome", modelo.for_nome);
            cmd.Parameters.AddWithValue("@for_rsocial", modelo.for_rsocial);
            cmd.Parameters.AddWithValue("@for_ie", modelo.for_ie);
            cmd.Parameters.AddWithValue("@for_cnpj", modelo.for_cnpj);
            cmd.Parameters.AddWithValue("@for_cep", modelo.for_cep);
            cmd.Parameters.AddWithValue("@est_nome", modelo.for_estado);
            cmd.Parameters.AddWithValue("@est_sgl", modelo.for_sgl);
            cmd.Parameters.AddWithValue("@for_cidade", modelo.for_cidade);
            cmd.Parameters.AddWithValue("@for_bairro", modelo.for_bairro);
            cmd.Parameters.AddWithValue("@for_logradouro", modelo.for_logradouro);
            cmd.Parameters.AddWithValue("@for_numero", modelo.for_numero);
            cmd.Parameters.AddWithValue("@end_complemento", modelo.for_complemento);
            cmd.Parameters.AddWithValue("@for_email", modelo.for_email);
            cmd.Parameters.AddWithValue("@for_telefone", modelo.for_telefone);
            cmd.Parameters.AddWithValue("@for_celular", modelo.for_celular);
        }
        public void Inserir(ModeloFornecedor modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spFornecedorInserir]", conexao._conexao);
                ParametrosFornecedor(modelo, cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                conexao.Conectar();
                modelo.for_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloFornecedor modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spFornecedorAlterar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@for_cod", modelo.for_cod);
                ParametrosFornecedor(modelo, cmd);
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
        public void Excuir(int cod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spFornecedorExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@for_cod", cod);
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
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spFornecedorConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@for_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloFornecedor CarregaModeloFornecedor(int cod)
        {
            try
            {
                ModeloFornecedor modelo = new ModeloFornecedor();
                SqlCommand cmd = new SqlCommand("[dbo].[spFornecedorConsultarCodigo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@for_cod", cod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.for_cod = Convert.ToInt32(dr["CODIGO"]);
                    modelo.for_nome = dr["NOME"].ToString();
                    modelo.for_rsocial = dr["RAZAO_SOCIAL"].ToString();
                    modelo.for_ie = dr["IE"].ToString();
                    modelo.for_cnpj = dr["CNPJ"].ToString();
                    modelo.for_cep = dr["CEP"].ToString();
                    modelo.for_estado = dr["ESTADO"].ToString();
                    modelo.for_sgl = dr["SIGLA"].ToString();
                    modelo.for_cidade = dr["CIDADE"].ToString();
                    modelo.for_bairro = dr["BAIRRO"].ToString();
                    modelo.for_logradouro = dr["LOGRADOURO"].ToString();
                    modelo.for_numero = dr["NUMERO"].ToString();
                    modelo.for_complemento = dr["COMPLEMENTO"].ToString();
                    modelo.for_email = dr["EMAIL"].ToString();
                    modelo.for_telefone = dr["TELEFONE"].ToString();
                    modelo.for_celular = dr["CELULAR"].ToString();
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
