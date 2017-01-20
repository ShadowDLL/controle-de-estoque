using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;
using System.Data;
using Ferramentas;
namespace BLL
{
    public class BLLCliente
    {
        private DALConexao conexao;
        public BLLCliente(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloCliente modelo)
        {
            if (modelo.cli_nome.Trim().Length < 1)
            {
                throw new Exception("nome");
            }
            modelo.cli_nome = modelo.cli_nome.ToUpper();

            modelo.cli_cpfcnpj = modelo.cli_cpfcnpj.Replace(".", "");
            modelo.cli_cpfcnpj = modelo.cli_cpfcnpj.Replace("-", "");
            modelo.cli_cpfcnpj = modelo.cli_cpfcnpj.Replace(",", "");
            modelo.cli_cpfcnpj = modelo.cli_cpfcnpj.Replace("/", "");
            modelo.cli_rgie = modelo.cli_rgie.Replace(".", "");
            modelo.cli_rgie = modelo.cli_rgie.Replace("-", "");
            modelo.cli_rgie = modelo.cli_rgie.Replace(",", "");
            if (modelo.cli_tipo == "JURIDICA")
            {
                if (modelo.cli_rsocial.Trim().Length < 1)
                {
                    throw new Exception("rsocial");
                }
                modelo.cli_rsocial = modelo.cli_rsocial.ToUpper();

                if (!Validacao.IsCnpj(modelo.cli_cpfcnpj))
                {
                    throw new Exception("cnpj");
                }
                if (modelo.cli_rgie.Trim().Length < 12)
                {
                    throw new Exception("ie");
                }
            }
            else
            {
                if (!Validacao.IsCpf(modelo.cli_cpfcnpj))
                {
                    throw new Exception("cpf");
                }
                if (modelo.cli_rgie.Trim().Length < 9)
                {
                    throw new Exception("rg");
                }
            }      

            modelo.cli_cep = modelo.cli_cep.Replace("-", "");
            if (modelo.cli_cep.Trim().Length < 8)
            {
                throw new Exception("cep");
            }
            if (modelo.cli_sgl.Trim().Length < 1)
            {
                throw new Exception("sgl");
            }
            if (modelo.cli_estado.Trim().Length < 2)
            {
                throw new Exception("estado");
            }
            modelo.cli_estado = modelo.cli_estado.ToUpper();

            if (modelo.cli_cidade.Trim().Length < 2)
            {
                throw new Exception("cidade");
            }
            modelo.cli_cidade = modelo.cli_cidade.ToUpper();

            if (modelo.cli_bairro.Trim().Length < 2)
            {
                throw new Exception("bairro");
            }
            modelo.cli_bairro = modelo.cli_bairro.ToUpper();

            if (modelo.cli_logradouro.Trim().Length < 2)
            {
                throw new Exception("endereco");
            }
            modelo.cli_logradouro = modelo.cli_logradouro.ToUpper();

            if (modelo.cli_numero.Trim().Length < 1)
            {
                throw new Exception("numero");
            }
            modelo.cli_numero = modelo.cli_numero.ToUpper();

            if (modelo.cli_complemento.Trim().Length < 1)
            {
                throw new Exception("complemento");
            }
            modelo.cli_complemento = modelo.cli_complemento.ToUpper();

            modelo.cli_email = modelo.cli_email.ToLower();
            if (!Validacao.IsEmail(modelo.cli_email))
            {
                throw new Exception("email");
            }

            modelo.cli_telefone = modelo.cli_telefone.Replace("(", "");
            modelo.cli_telefone = modelo.cli_telefone.Replace(")", "");
            modelo.cli_telefone = modelo.cli_telefone.Replace("-", "");
            if (modelo.cli_telefone.Trim().Length < 10)
            {
                throw new Exception("telefone");
            }

            modelo.cli_celular = modelo.cli_celular.Replace("(", "");
            modelo.cli_celular = modelo.cli_celular.Replace(")", "");
            modelo.cli_celular = modelo.cli_celular.Replace("-", "");
            if (modelo.cli_celular.Trim().Length < 11)
            {
                throw new Exception("celular");
            }
        }
        public void Inserir(ModeloCliente modelo)
        {
            ValidaCampos(modelo);
            DALCliente DALObj = new DALCliente(conexao);
            DALObj.Inserir(modelo);
        }
        public void Alterar(ModeloCliente modelo)
        {
            if (modelo.cli_cod < 1)
            {
                throw new Exception("codigo");
            }
            ValidaCampos(modelo);
            DALCliente DALObj = new DALCliente(conexao);
            DALObj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALCliente DALObj = new DALCliente(conexao);
            DALObj.Excluir(cod);
        }
        public DataTable LocalizarNome(string valor)
        {
            DALCliente DALObj = new DALCliente(conexao);
            return DALObj.LocalizarNome(valor);
        }
        public ModeloCliente CarregaModeloCliente(int cod)
        {
            DALCliente DALObj = new DALCliente(conexao);
            return DALObj.CarregaModeloCliente(cod);
        }
    }
}
