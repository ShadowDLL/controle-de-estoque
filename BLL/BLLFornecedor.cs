using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferramentas;
using System.Data;

namespace BLL
{
    public class BLLFornecedor
    {
        private DALConexao conexao;
        public BLLFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ValidaCampos(ModeloFornecedor modelo)
        {
            if (modelo.for_nome.Trim().Length < 1)
            {
                throw new Exception("nome");
            }
            modelo.for_nome = modelo.for_nome.ToUpper();
            if (modelo.for_rsocial.Trim().Length < 1)
            {
                throw new Exception("rsocial");
            }
            modelo.for_rsocial = modelo.for_rsocial.ToUpper();
            modelo.for_cnpj = modelo.for_cnpj.Replace(".", "");
            modelo.for_cnpj = modelo.for_cnpj.Replace(",", "");
            modelo.for_cnpj = modelo.for_cnpj.Replace("/", "");
            modelo.for_cnpj = modelo.for_cnpj.Replace("-", "");
            if (!Validacao.IsCnpj(modelo.for_cnpj))
            {
                throw new Exception("cnpj");
            }
            if (modelo.for_ie.Trim().Length < 15)
            {
                throw new Exception("ie");
            }
            modelo.for_ie = modelo.for_ie.ToUpper();
            modelo.for_cep = modelo.for_cep.Replace("-", "");
            if (modelo.for_cep.Trim().Length < 8)
            {
                throw new Exception("cep");
            }
            if (modelo.for_sgl.Trim().Length < 1)
            {
                throw new Exception("sgl");
            }
            if (modelo.for_estado.Trim().Length < 2)
            {
                throw new Exception("estado");
            }
            modelo.for_estado = modelo.for_estado.ToUpper();

            if (modelo.for_cidade.Trim().Length < 2)
            {
                throw new Exception("cidade");
            }
            modelo.for_cidade = modelo.for_cidade.ToUpper();

            if (modelo.for_bairro.Trim().Length < 2)
            {
                throw new Exception("bairro");
            }
            modelo.for_bairro = modelo.for_bairro.ToUpper();

            if (modelo.for_logradouro.Trim().Length < 2)
            {
                throw new Exception("logradouro");
            }
            modelo.for_logradouro = modelo.for_logradouro.ToUpper();

            if (modelo.for_numero.Trim().Length < 1)
            {
                throw new Exception("numero");
            }
            modelo.for_numero = modelo.for_numero.ToUpper();

            if (modelo.for_complemento.Trim().Length < 1)
            {
                throw new Exception("complemento");
            }
            modelo.for_logradouro = modelo.for_logradouro.ToUpper();

            modelo.for_email = modelo.for_email.ToLower();
            if (!Validacao.IsEmail(modelo.for_email))
            {
                throw new Exception("email");
            }

            modelo.for_telefone = modelo.for_telefone.Replace("(", "");
            modelo.for_telefone = modelo.for_telefone.Replace(")", "");
            modelo.for_telefone = modelo.for_telefone.Replace("-", "");
            if (modelo.for_telefone.Trim().Length < 10)
            {
                throw new Exception("telefone");
            }

            modelo.for_celular = modelo.for_celular.Replace("(", "");
            modelo.for_celular = modelo.for_celular.Replace(")", "");
            modelo.for_celular = modelo.for_celular.Replace("-", "");
            if (modelo.for_celular.Trim().Length < 11)
            {
                throw new Exception("celular");
            }

        }
        public void Inserir(ModeloFornecedor modelo)
        {
            ValidaCampos(modelo);
            DALFornecedor DALObj = new DALFornecedor(conexao);
            DALObj.Inserir(modelo);
        }
        public void Alterar(ModeloFornecedor modelo)
        {
            ValidaCampos(modelo);
            DALFornecedor DALObj = new DALFornecedor(conexao);
            DALObj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALFornecedor DALObj = new DALFornecedor(conexao);
            DALObj.Excuir(cod);
        }
        public DataTable Localizar(string valor)
        {
            DALFornecedor DALObj = new DALFornecedor(conexao);
            return DALObj.LocalizarNome(valor);
        }
        public ModeloFornecedor CarregaModeloFornecedor(int cod)
        {
            DALFornecedor DALObj = new DALFornecedor(conexao);
            return DALObj.CarregaModeloFornecedor(cod);
        }
    }
}
