using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL;

namespace Ferramentas
{
    public class BuscaEndereco
    {
        #region "Variáveis"
        static public string cep = "";
        static public string cidade = "";
        static public string estado = "";
        static public string endereco = "";
        static public string bairro = "";
        #endregion

        #region "Funções"
        public static Boolean verificaCEP(String CEP)
        {
            bool flag = false;
            try
            {
                DataSet ds = new DataSet();
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);
                ds.ReadXml(xml);
                endereco = ds.Tables[0].Rows[0]["logradouro"].ToString();
                bairro = ds.Tables[0].Rows[0]["bairro"].ToString();
                cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                estado = ds.Tables[0].Rows[0]["uf"].ToString();
                cep = CEP;
                flag = (estado == "") ? false : true;
            }
            catch (Exception erro)
            {
                cep = "";
                cidade = "";
                estado = "";
                endereco = "";
                bairro = "";
                cep = "";
                throw new Exception(erro.Message);
            }
            return flag;
        }
        private static DataTable ConsultarEndereco(string comando)
        {
            DataTable tabela = new DataTable();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            SqlDataAdapter da = new SqlDataAdapter(comando, cx._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(tabela);
            return tabela;
        }
        private static DataTable CombinarEndereco(string comando, string parametro)
        {
            DataTable tabela = new DataTable();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            SqlDataAdapter da = new SqlDataAdapter(comando, cx._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@p", parametro);
            da.Fill(tabela);
            return tabela;
        }
        public static DataTable ConsultarEstadoSgl()
        {
            return ConsultarEndereco("[dbo].[spEstadoConsultarSigla]");
        }
        public static DataTable CombinarCepSigla(string parametro)
        {
            return CombinarEndereco("[dbo].[spCombinarCepSigla]", parametro);
        }
        public static DataTable CombinarSiglaEstado(string parametro)
        {
            return CombinarEndereco("[dbo].[spCombinarSiglaEstado]", parametro);
        }
        public static DataTable CombinarEstadoCidade(string parametro)
        {
            return CombinarEndereco("[dbo].[spCombinarEstadoCidade]", parametro);
        }
        public static DataTable CombinarCidadeBairro(string parametro)
        {
            return CombinarEndereco("[dbo].[spCombinarCidadeBairro]", parametro);
        }
        public static DataTable CombinarBairroLogradouro(string parametro)
        {
            return CombinarEndereco("[dbo].[spCombinarBairroLogradouro]", parametro);
        }
      
        #endregion
    }
}
