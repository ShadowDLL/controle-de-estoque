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
    public class DALCompra
    {
        private DALConexao conexao;
        public DALCompra(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void CarregaModelo(ModeloCompra modeloCompra, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@com_data", modeloCompra.com_data);
            cmd.Parameters.AddWithValue("@com_nfiscal", modeloCompra.com_nfiscal);
            cmd.Parameters.AddWithValue("@com_total", modeloCompra.com_total);
            cmd.Parameters.AddWithValue("@com_nparcelas", modeloCompra.com_nparcelas);
            cmd.Parameters.AddWithValue("@for_cod", modeloCompra.for_cod);
            cmd.Parameters.AddWithValue("@tpa_cod", modeloCompra.tpa_cod);
        }
        public void Inserir(ModeloCompra modeloCompra)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spCompraInserir]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            CarregaModelo(modeloCompra, cmd);
            modeloCompra.com_cod = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void Alterar(ModeloCompra modeloCompra)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[spCompraAlterar]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@com_cod", modeloCompra.com_cod);
            CarregaModelo(modeloCompra, cmd);
            cmd.ExecuteScalar();
        }
        public void Excluir(int cod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spCompraExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@com_cod", cod);
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
        public void Cancelar(int cod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spCompraCancelar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@com_cod", cod);
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
        //Localizar pelo código do fornecedor 
        public DataTable Localizar(int for_cod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spCompraLocalizarFornecedorCod]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@for_cod", for_cod);
            da.Fill(tabela);
            return tabela;
        }
        //Localizar pelo nome do fornecedor
        public DataTable Localizar(string nome)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spCompraLocalizarFornecedorNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@for_nome", nome);
            da.Fill(tabela);
            return tabela;
        }
        //Localizar todas as compras
        public DataTable Localizar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spCompraConsultar]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(tabela);
            return tabela;
        }
        //Localizar por parcelas em aberto
        public DataTable LocalizarParcelasEmAberto()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spCompraConsultarAtiva]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(tabela);
            return tabela;
        }
        //Localizar pela data da compra
        public DataTable Localizar(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spCompraLocalizarFornecedorData]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@com_dataInicial", SqlDbType.DateTime).Value = dataInicial;
            da.SelectCommand.Parameters.Add("@com_dataFinal", SqlDbType.DateTime).Value = dataFinal;
            da.Fill(tabela);
            return tabela;
        }
        public ModeloCompra CarregaModeloCompra(int cod)
        {
            try
            {
                ModeloCompra modeloCompra = new ModeloCompra();
                SqlCommand cmd = new SqlCommand("[dbo].[spCompraConsultarCod]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@com_cod", cod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modeloCompra.com_cod = Convert.ToInt32(dr["CODIGO"]);
                    modeloCompra.com_data = Convert.ToDateTime(dr["DATA"]);
                    modeloCompra.com_nfiscal = Convert.ToInt32(dr["NOTA_FISCAL"]);
                    modeloCompra.com_total = Convert.ToDouble(dr["TOTAL"]);
                    modeloCompra.com_nparcelas = Convert.ToInt32(dr["NUMERO_PARCELAS"]);
                    modeloCompra.com_status = dr["STATUS"].ToString();
                    modeloCompra.for_cod = Convert.ToInt32(dr["CODIGO_FORNECEDOR"]);
                    modeloCompra.tpa_cod = Convert.ToInt32(dr["TIPO_PAGAMENTO"]);
                }
                return modeloCompra;
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
        public int QuantidadeParcelasNaoPagas(int comcod)
        {
            int qtd = 0;
            SqlCommand cmd = new SqlCommand("[dbo].[spCompraQuantidadeParcelasNaoPagas]", conexao._conexao);
            cmd.Transaction = conexao.ObjetoTransacao;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@com_cod", comcod);
            qtd = Convert.ToInt32(cmd.ExecuteScalar());
            return qtd;
        }
        public void ParcelasCompraPagar(int comcod, int pcocod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraPagar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@com_cod", comcod);
                cmd.Parameters.AddWithValue("@pco_cod", pcocod);
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
        public void ParcelasCompraCancelar(int comcod, int pcocod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasCompraCancelar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@com_cod", comcod);
                cmd.Parameters.AddWithValue("@pco_cod", pcocod);
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
        public void AtualizaStatusCompra(int comcod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spAtualizaStatusCompra]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@com_cod", comcod);
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
    }
}
