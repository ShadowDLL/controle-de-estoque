using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using Ferramentas;
using System.Data;

namespace BLL
{
    public class BLLUsuario
    {
        private DALConexao conexao;
        public BLLUsuario(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloUsuario modelo)
        {
            if (modelo.usu_nome.Trim().Length < 1)
            {
                throw new Exception("nome");
            }
            modelo.usu_nome = modelo.usu_nome.ToUpper();

            modelo.usu_cpf = modelo.usu_cpf.Replace(".", "");
            modelo.usu_cpf = modelo.usu_cpf.Replace("-", "");
            modelo.usu_cpf = modelo.usu_cpf.Replace(",", "");
            if (!Validacao.IsCpf(modelo.usu_cpf))
            {
                throw new Exception("cpf");
            }

            modelo.usu_rg = modelo.usu_rg.Replace(".", "");
            modelo.usu_rg = modelo.usu_rg.Replace("-", "");
            modelo.usu_rg = modelo.usu_rg.Replace(",", "");
            if (modelo.usu_rg.Trim().Length < 9)
            {
                throw new Exception("rg");
            }

            modelo.usu_cep = modelo.usu_cep.Replace("-", "");
            if (modelo.usu_cep.Trim().Length < 8)
            {
                throw new Exception("cep");
            }
            if (modelo.usu_sgl.Trim().Length < 1)
            {
                throw new Exception("sgl");
            }
            if (modelo.usu_estado.Trim().Length < 2)
            {
                throw new Exception("estado");
            }
            modelo.usu_estado = modelo.usu_estado.ToUpper();

            if (modelo.usu_cidade.Trim().Length < 2)
            {
                throw new Exception("cidade");
            }
            modelo.usu_cidade = modelo.usu_cidade.ToUpper();

            if (modelo.usu_bairro.Trim().Length < 2)
            {
                throw new Exception("bairro");
            }
            modelo.usu_bairro = modelo.usu_bairro.ToUpper();

            if (modelo.usu_logradouro.Trim().Length < 2)
            {
                throw new Exception("logradouro");
            }
            modelo.usu_logradouro = modelo.usu_logradouro.ToUpper();

            if (modelo.usu_numero.Trim().Length < 1)
            {
                throw new Exception("numero");
            }
            modelo.usu_numero = modelo.usu_numero.ToUpper();

            if (modelo.usu_complemento.Trim().Length < 1)
            {
                throw new Exception("complemento");
            }
            modelo.usu_complemento = modelo.usu_complemento.ToUpper();

            modelo.usu_email = modelo.usu_email.ToLower();
            if (!Validacao.IsEmail(modelo.usu_email)) 
            {
                throw new Exception("email");
            }

            modelo.usu_telefone = modelo.usu_telefone.Replace("(", "");
            modelo.usu_telefone = modelo.usu_telefone.Replace(")", "");
            modelo.usu_telefone = modelo.usu_telefone.Replace("-", "");
            if (modelo.usu_telefone.Trim().Length < 10)
            {
                throw new Exception("telefone");
            }

            modelo.usu_celular = modelo.usu_celular.Replace("(", "");
            modelo.usu_celular = modelo.usu_celular.Replace(")", "");
            modelo.usu_celular = modelo.usu_celular.Replace("-", "");
            if (modelo.usu_celular.Trim().Length < 11)
            {
                throw new Exception("celular");
            }

            if (modelo.usu_login.Trim().Length < 1)
            {
                throw new Exception("login");
            }

            if (modelo.usu_senha.Trim().Length < 1)
            {
                throw new Exception("senha");
            }

            if (modelo.usu_lembretesenha.Trim().Length < 1)
            {
                throw new Exception("lembretesenha");
            }
            modelo.usu_lembretesenha = modelo.usu_lembretesenha.ToUpper();

        }
        public void Inserir(ModeloUsuario modelo)
        {
            ValidaCampos(modelo);
            DALUsuario DALObj = new DALUsuario(conexao);
            DALObj.Inserir(modelo);
        }
        public void Alterar(ModeloUsuario modelo)
        {
            if (modelo.usu_cod < 1)
            {
                throw new Exception("codigo");
            }
            ValidaCampos(modelo);
            DALUsuario DALObj = new DALUsuario(conexao);
            DALObj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALUsuario DALObj = new DALUsuario(conexao);
            DALObj.Excluir(cod);
        }
        public DataTable LocalizarNome(string valor)
        {
            DALUsuario DALObj = new DALUsuario(conexao);
            return DALObj.LocalizarNome(valor);
        }
        public ModeloUsuario CarregaModeloUsuario(int cod)
        {
            DALUsuario DALObj = new DALUsuario(conexao);
            return DALObj.CarregaModeloUsuario(cod);
        }
        public DataTable LocalizarNomeLogin(string valor)
        {
            DALUsuario DALObj = new DALUsuario(conexao);
            return DALObj.LocalizarLogin(valor);
        }
        public bool LoginDisponivel(string login)
        {
            DALUsuario DALObj = new DALUsuario(conexao);
            return DALObj.LoginDisponivel(login);
        }
        public ModeloUsuario UsuarioLogar(ModeloUsuario modelo)
        {
            DALUsuario DALObjeto = new DALUsuario(conexao);
            return DALObjeto.UsuarioLogar(modelo);
        }
    }
}
