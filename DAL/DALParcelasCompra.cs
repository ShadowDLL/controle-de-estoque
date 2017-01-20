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
    public class DALParcelasCompra
    {
        private DALConexao conexao;
        public DALParcelasCompra(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ParcelaCadastraAtualiza(ModeloParcelasCompra modelo)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraInserir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pcocompra", modelo.parcelascompra);
            cmd.ExecuteNonQuery();
        }
        public void EfetuaPagamentoParcela(int comcod, int pcocod, DateTime dtppagto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraPagar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pco_cod", pcocod);
                cmd.Parameters.AddWithValue("@pco_datapagto", dtppagto);
                cmd.Parameters.AddWithValue("@comcod", comcod);
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
        public void Alterar(ModeloParcelasCompra modelo)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraAlterar]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pco_cod", modelo.pco_cod);
            cmd.Parameters.AddWithValue("@pco_valor", modelo.pco_valor);
            cmd.Parameters.AddWithValue("@pco_datapagto", modelo.pco_datapagto);
            cmd.Parameters.AddWithValue("@pco_datavecto", modelo.pco_datavecto);
            cmd.Parameters.AddWithValue("@comcod", modelo.com_cod);
            cmd.ExecuteNonQuery();
        }
        public void Excluir(ModeloParcelasCompra modelo)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraExcluir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pco_cod", modelo.pco_cod);
            cmd.Parameters.AddWithValue("@comcod", modelo.com_cod);
            cmd.ExecuteNonQuery();
        }
        public void ExcluirTodasParcelas(int comcod)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraExcluir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@comcod", comcod);
            cmd.ExecuteNonQuery();
        }
        public DataTable Localizar(int comcod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spParcelasCompraLocalizar]", conexao._conexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@comcod", comcod);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloParcelasCompra CarregaModeloParcelasCompra(int pcocod, int comcod)
        {
            try
            {
                ModeloParcelasCompra modelo = new ModeloParcelasCompra();
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraLocalizarCarrega]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pcocod", pcocod);
                cmd.Parameters.AddWithValue("@comcod", comcod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.pco_cod = Convert.ToInt32(dr["CODIGO"]);
                    modelo.pco_valor = Convert.ToInt32(dr["VALOR_PARCELA"]);
                    modelo.pco_datapagto = Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                    modelo.pco_datavecto = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                    modelo.com_cod = Convert.ToInt32(dr["CODIGO_COMPRA"]);
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
