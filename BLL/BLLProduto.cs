using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProduto
    {
        private DALConexao conexao;
        public BLLProduto(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloProduto modeloProduto)
        {
            if (modeloProduto.ProNome.Trim().Length == 0)
            {
                throw new Exception("nome");
            }
            modeloProduto.ProNome = modeloProduto.ProNome.ToUpper();
            if (modeloProduto.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("descricao");
            }
            modeloProduto.ProDescricao = modeloProduto.ProDescricao.ToUpper();

            if (modeloProduto.ProValorPago <= 0)
            {
                throw new Exception("valorpago");
            }
            if (modeloProduto.ProValorVenda <= 0)
            {
                throw new Exception("valorvenda");
            }
            if (modeloProduto.ScatCod <= 0)
            {
                throw new Exception("scatcod");
            }
            if (modeloProduto.CatCod <= 0)
            {
                throw new Exception("catcod");
            }
            if (modeloProduto.UmedCod <= 0)
            {
                throw new Exception("umedcod");
            }
        }
        public void Inserir(ModeloProduto modelo)
        {
            ValidaCampos(modelo);
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Inserir(modelo);
        }
        public void Alterar(ModeloProduto modelo)
        {
            if (modelo.ProCod <= 0)
            {
                throw new Exception("ProCod");
            }
            ValidaCampos(modelo);
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable Localizar(string valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloProduto CarregaModeloProduto(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }
    } 
}
