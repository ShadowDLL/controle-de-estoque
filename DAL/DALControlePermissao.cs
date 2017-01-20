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
    public class DALControlePermissao
    {
        private DALConexao conexao;
        public DALControlePermissao(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Inserir(DataTable permissao, int usucod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioControlePermissaoCadastrar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par = cmd.Parameters.AddWithValue("@permissao", permissao);
                par.SqlDbType = SqlDbType.Structured;
                cmd.Parameters.AddWithValue("@usucod", usucod);         
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
        public DataTable Localizar(int usucod)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spUsuarioControlePermissaoConsultarCodigo]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@usucod", usucod);
            da.Fill(tabela);
            ModeloControlePermissao.per_permissoes = tabela;
            return tabela;
        }
    }
}
