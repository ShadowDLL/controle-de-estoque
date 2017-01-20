using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConexao
    {
        public string _stringConexao { get; set; }
        public SqlConnection _conexao { get; set; }
        public SqlTransaction ObjetoTransacao { get; set; }

        public DALConexao(string dadosConexao)
        {
            this._conexao = new SqlConnection();
            this._stringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }
        public void Conectar()
        {
            this._conexao.Open();
        }
        public void Desconectar()
        {
            this._conexao.Close();
        }
        public void IniciaTransacao()
        {
            this.ObjetoTransacao = _conexao.BeginTransaction();
        }
        public void FinalizaTransacao()
        {
            this.ObjetoTransacao.Commit();
        }
        public void CancelaTransacao()
        {
            this.ObjetoTransacao.Rollback();
        }
    }
}
