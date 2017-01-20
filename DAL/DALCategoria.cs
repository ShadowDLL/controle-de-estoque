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
    public class DALCategoria
    {
        private DALConexao conexao;
        public DALCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spCategoriaInserir]");
                cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cat_nome", modelo.catnome);
                conexao.Conectar();
                modelo.cat_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spCategoriaAlterar]");
                cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cat_cod", modelo.cat_cod);
                cmd.Parameters.AddWithValue("@cat_nome", modelo.catnome);
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
        public void Exluir(int cod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spCategoriaExcluir]");
                cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cat_cod", cod);
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
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spCategoriaConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@cat_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            try
            {
                ModeloCategoria modelo = new ModeloCategoria();
                SqlCommand cmd = new SqlCommand("[dbo].[spCategoriaConsultarCodigo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cat_cod", codigo);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.cat_cod = Convert.ToInt32(registro["CODIGO_CATEGORIA"]);
                    modelo.catnome = Convert.ToString(registro["NOME"]);
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
