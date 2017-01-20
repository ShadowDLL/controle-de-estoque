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
    public class DALProduto
    {
        private DALConexao conexao;
        public DALProduto(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ParametrosProduto(ModeloProduto modelo, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@pro_nome", modelo.ProNome);
            cmd.Parameters.AddWithValue("@pro_descricao", modelo.ProDescricao);
            if (modelo.ProFoto == null)
            {
                cmd.Parameters.Add("@pro_foto", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@pro_foto", SqlDbType.Image).Value = modelo.ProFoto; ;
            }
            cmd.Parameters.AddWithValue("@pro_valorpago", modelo.ProValorPago);
            cmd.Parameters.AddWithValue("@pro_valorvenda", modelo.ProValorVenda);
            cmd.Parameters.AddWithValue("@pro_qtde", modelo.ProQtde);
            cmd.Parameters.AddWithValue("@umed_cod", modelo.UmedCod);
            cmd.Parameters.AddWithValue("@cat_cod", modelo.CatCod);
            cmd.Parameters.AddWithValue("@scat_cod", modelo.ScatCod);
        }
        public void Inserir(ModeloProduto modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spProdutoInserir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                ParametrosProduto(modelo, cmd);
                conexao.Conectar();
                modelo.ProCod = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public void Alterar(ModeloProduto modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spProdutoAlterar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);
                ParametrosProduto(modelo, cmd);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                SqlCommand cmd = new SqlCommand("[dbo].[spProdutoExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pro_cod", cod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spProdutoConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@pro_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloProduto CarregaModeloProduto(int cod)
        {
            try
            {
                ModeloProduto modelo = new ModeloProduto();
                SqlCommand cmd = new SqlCommand("[dbo].[spProdutoConsultarCodigo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pro_cod", cod);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.ProCod = Convert.ToInt32(registro["CODIGO"]);
                    modelo.ProNome = registro["NOME"].ToString();
                    modelo.ProDescricao = registro["DESCRICAO"].ToString();
                    try
                    {
                        modelo.ProFoto = (byte[])registro["FOTO"];
                    }
                    catch { }
                    modelo.ProValorPago = Convert.ToDouble(registro["VALOR_PAGO"]);
                    modelo.ProValorVenda = Convert.ToDouble(registro["VALOR_VENDA"]);
                    modelo.ProQtde = Convert.ToInt32(registro["QUANTIDADE"]);
                    modelo.UmedCod = Convert.ToInt32(registro["CODIGO_UNIDADE_MEDIDA"]);
                    modelo.CatCod = Convert.ToInt32(registro["CODIGO_CATEGORIA"]);
                    modelo.ScatCod = Convert.ToInt32(registro["CODIGO_SUB_CATEGORIA"]);
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
