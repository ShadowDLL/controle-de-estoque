using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using DAL;

namespace BLL
{
    public class BLLTipoPagamento
    {
        private DALConexao conexao;
        public BLLTipoPagamento(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloTipoPagamento modelo)
        {
            if (modelo.tpa_nome.Trim().Length == 0)
            {
                throw new Exception("nome");
            }
            modelo.tpa_nome = modelo.tpa_nome.ToUpper();
        }
        public void Inserir(ModeloTipoPagamento modelo)
        {
            ValidaCampos(modelo);
            DALTipoPagamento DALObj = new DALTipoPagamento(conexao);
            DALObj.Inserir(modelo);
        }
        public void Alterar(ModeloTipoPagamento modelo)
        {
            ValidaCampos(modelo);
            if (modelo.tpa_cod <= 0)
            {
                throw new Exception("codigo");
            }
            DALTipoPagamento DALObj = new DALTipoPagamento(conexao);
            DALObj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALTipoPagamento DALObj = new DALTipoPagamento(conexao);
            DALObj.Excluir(cod);
        }
        public DataTable Localizar(string valor)
        {
            DALTipoPagamento DALObj = new DALTipoPagamento(conexao);
            return DALObj.Localizar(valor);
        }
        public ModeloTipoPagamento CarregaModeloTipoPagamento(int cod)
        {
            DALTipoPagamento DALObj = new DALTipoPagamento(conexao);
            return DALObj.CarregaModeloTipoPagamento(cod);
        }
    }
}
