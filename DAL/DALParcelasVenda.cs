using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace DAL
{
    public class DALParcelasVenda
    {
        private DALConexao conexao;
        public DALParcelasVenda(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Inserir(ModeloParcelasVenda modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasVendaInserir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ven_cod", modelo.ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", modelo.pve_cod);
                cmd.Parameters.AddWithValue("@pve_valor", modelo.pve_valor);
                cmd.Parameters.AddWithValue("@pve_datapagto", modelo.pve_datapagto);
                cmd.Parameters.AddWithValue("@pve_datavecto", modelo.pve_datavecto);
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
        public void Alterar(ModeloParcelasVenda modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasVendaAlterar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ven_cod", modelo.ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", modelo.pve_cod);
                cmd.Parameters.AddWithValue("@pve_valor", modelo.pve_valor);
                cmd.Parameters.AddWithValue("@pve_datapagto", modelo.pve_datapagto);
                cmd.Parameters.AddWithValue("@pve_datavecto", modelo.pve_datavecto);
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
        public void Excluir(ModeloParcelasVenda modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasVendaExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ven_cod", modelo.ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", modelo.pve_cod);
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
        public void ExcluirTodasParcelas(int vencod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasVendaExcluirTodas]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ven_cod", vencod);
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
        public DataTable Localizar(int vencod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spParcelasVendaLocalizar]", conexao._conexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ven_cod", vencod);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloParcelasVenda CarregaModeloParcelasVenda(int ven_cod, int pve_cod)
        {
            try
            {
                ModeloParcelasVenda modelo = new ModeloParcelasVenda();
                SqlCommand cmd = new SqlCommand("[dbo].[spParcelasVendaCarregaModelo]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ven_cod", ven_cod);
                cmd.Parameters.AddWithValue("@pve_cod", pve_cod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.ven_cod = Convert.ToInt32(dr["CODIGO"]);
                    modelo.pve_cod = Convert.ToInt32(dr["CODIGO_PARCELA"]);
                    modelo.pve_valor = Convert.ToInt32(dr["VALOR"]);
                    modelo.pve_datapagto = Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                    modelo.pve_datavecto = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
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
