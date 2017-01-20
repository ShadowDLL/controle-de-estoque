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
    public class DALSubCategoria
    {
        private DALConexao conexao;
        public DALSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloSubCategoria modeloSubCategoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spSubCategoriaInserir]");
                cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cat_cod", modeloSubCategoria.cat_cod);
                cmd.Parameters.AddWithValue("@scat_nome", modeloSubCategoria.snome);
                conexao.Conectar();
                modeloSubCategoria.scat_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloSubCategoria modeloSubCategoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spSubCategoriaAlterar]");
                cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@scat_cod", modeloSubCategoria.scat_cod);
                cmd.Parameters.AddWithValue("@scat_nome", modeloSubCategoria.snome);
                cmd.Parameters.AddWithValue("@cat_cod", modeloSubCategoria.cat_cod);
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
                SqlCommand cmd = new SqlCommand("[dbo].[spSubCategoriaExcluir]");
                cmd.Connection = conexao._conexao;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@scat_cod", cod);
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
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spSubCategoriaConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@scat_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarPorCategoria(int codigo)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spLocalizarPorCategoria]", conexao._conexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@cat_cod", codigo);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            try
            {
                ModeloSubCategoria modelo = new ModeloSubCategoria();
                SqlCommand cmd = new SqlCommand("[dbo].[spSubCategoriaConsultarCodigo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@scat_cod", codigo);
                conexao.Conectar();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    modelo.scat_cod = Convert.ToInt32(registro["CODIGO_SUBCATEGORIA"]);
                    modelo.snome = Convert.ToString(registro["NOME_SUBCATEGORIA"]);
                    modelo.cat_cod = Convert.ToInt32(registro["CODIGO_CATEGORIA"]);
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
