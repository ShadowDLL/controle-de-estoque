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
    public class DALUsuario
    {
        private DALConexao conexao;
        public DALUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ParametrosUsuario(ModeloUsuario modelo, SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usu_nome", modelo.usu_nome);
            cmd.Parameters.AddWithValue("@usu_cpf", modelo.usu_cpf);
            cmd.Parameters.AddWithValue("@usu_rg", modelo.usu_rg);
            cmd.Parameters.AddWithValue("@usu_cep", modelo.usu_cep);
            cmd.Parameters.AddWithValue("@est_nome", modelo.usu_estado);
            cmd.Parameters.AddWithValue("@est_sgl", modelo.usu_sgl);
            cmd.Parameters.AddWithValue("@usu_cidade", modelo.usu_cidade);
            cmd.Parameters.AddWithValue("@usu_logradouro", modelo.usu_logradouro);
            cmd.Parameters.AddWithValue("@usu_numero", modelo.usu_numero);
            cmd.Parameters.AddWithValue("@end_complemento", modelo.usu_complemento);
            cmd.Parameters.AddWithValue("@usu_bairro", modelo.usu_bairro);
            cmd.Parameters.AddWithValue("@usu_email", modelo.usu_email);
            cmd.Parameters.AddWithValue("@usu_telefone", modelo.usu_telefone);
            cmd.Parameters.AddWithValue("@usu_celular", modelo.usu_celular);
            cmd.Parameters.AddWithValue("@usu_login", modelo.usu_login);
            cmd.Parameters.AddWithValue("@usu_senha", modelo.usu_senha);
            cmd.Parameters.AddWithValue("@usu_lembretesenha", modelo.usu_lembretesenha);
        }
        public void Inserir(ModeloUsuario modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioInserir]", conexao._conexao);
                ParametrosUsuario(modelo, cmd);
                conexao.Conectar();
                modelo.usu_cod = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(ModeloUsuario modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioAlterar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_cod", modelo.usu_cod);
                ParametrosUsuario(modelo, cmd);
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
        public void Excluir(int cod)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioExcluir]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_cod", cod);
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
        public DataTable LocalizarNome(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spUsuarioConsultarNome]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@usu_nome", valor);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarLogin(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("[dbo].[spUsuarioConsultarLogin]", conexao._stringConexao);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@usu_login", valor);
            da.Fill(tabela);
            return tabela;
        }
        public bool LoginDisponivel(string login)
        {
            try
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioConsultarExiteLogin]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_login", login);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
                return flag;
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
        public ModeloUsuario CarregaModeloUsuario(int cod)
        {
            try
            {
                ModeloUsuario modelo = new ModeloUsuario();
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioConsultarCod]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_cod", cod);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.usu_cod = Convert.ToInt32(dr["CODIGO"]);
                    modelo.usu_nome = dr["NOME"].ToString();
                    modelo.usu_cpf = dr["CPF"].ToString();
                    modelo.usu_rg = dr["RG"].ToString();
                    modelo.usu_cep = dr["CEP"].ToString();
                    modelo.usu_estado = dr["ESTADO"].ToString();
                    modelo.usu_sgl = dr["SIGLA"].ToString();
                    modelo.usu_cidade = dr["CIDADE"].ToString();
                    modelo.usu_bairro = dr["BAIRRO"].ToString();
                    modelo.usu_logradouro = dr["LOGRADOURO"].ToString();
                    modelo.usu_numero = dr["NUMERO"].ToString();
                    modelo.usu_complemento = dr["COMPLEMENTO"].ToString();
                    modelo.usu_email = dr["EMAIL"].ToString();
                    modelo.usu_telefone = dr["TELEFONE"].ToString();
                    modelo.usu_celular = dr["CELULAR"].ToString();
                    modelo.usu_login = dr["LOGIN"].ToString();
                    modelo.usu_senha = dr["SENHA"].ToString();
                    modelo.usu_lembretesenha = dr["LEMBRETE_SENHA"].ToString();
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
        public ModeloUsuario UsuarioLogar(ModeloUsuario modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[spUsuarioLogar]", conexao._conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usulogin", modelo.usu_login);
                cmd.Parameters.AddWithValue("@ususenha", modelo.usu_senha);
                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    modelo.usu_nome = dr["NOME"].ToString();
                    modelo.usu_cod = Convert.ToInt32(dr["CODIGO"]);
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
