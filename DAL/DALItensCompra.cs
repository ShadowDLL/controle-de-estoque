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
    public class DALItensCompra
    {
        private DALConexao conexao;
        public DALItensCompra(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ItensCadastrarAtualizar(ModeloItensCompra modelo)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spItensCompraInserir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@itens", modelo.itenscompra);
            cmd.ExecuteNonQuery();
        }
        public void Alterar(ModeloItensCompra modelo)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spItensCompraAlterar]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", modelo.itc_cod);
            cmd.Parameters.AddWithValue("@qtde", modelo.itc_qtde);
            cmd.Parameters.AddWithValue("@valor", modelo.itc_valor);
            cmd.Parameters.AddWithValue("@comcod", modelo.com_cod);
            cmd.Parameters.AddWithValue("@procod", modelo.pro_cod);
            cmd.ExecuteNonQuery();
        }
        public void Excluir(ModeloItensCompra modelo)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spItensCompraExcluir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", modelo.itc_cod);
            cmd.Parameters.AddWithValue("@comcod", modelo.com_cod);
            cmd.Parameters.AddWithValue("@procod", modelo.pro_cod);
            cmd.ExecuteNonQuery();
        }
        public void ExcluirTodosItens(int cod)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spItensCompraExcluir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@comcod", cod);
            cmd.ExecuteNonQuery();
        }
        public DataTable Localizar(int cod)
        {
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spItensCompraConsultarCod]", conexao._conexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@cod", cod);
            da.Fill(table);
            return table;
        }
        public ModeloItensCompra CarregaModeloItensCompra(int ItcCod, int ComCod, int ProCod)
        {
            try
            {
                ModeloItensCompra modelo = new ModeloItensCompra();
                SqlCommand cmd = new SqlCommand("[dbo].[spItensCompraConsultar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@itc_cod", ItcCod);
                cmd.Parameters.AddWithValue("@com_cod", ComCod);
                cmd.Parameters.AddWithValue("@pro_cod", ProCod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.itc_cod = Convert.ToInt32(dr["CODIGO"]);
                    modelo.itc_qtde = Convert.ToInt32(dr["QUANTIDADE"]);
                    modelo.itc_valor = Convert.ToInt32(dr["VALOR_UNITARIO"]);
                    modelo.com_cod = Convert.ToInt32(dr["CODIGO_COMPRA"]);
                    modelo.pro_cod = Convert.ToInt32(dr["CODIGO_PRODUTO"]);
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
