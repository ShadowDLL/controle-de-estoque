using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLParcelasCompra
    {
        private DALConexao conexao;
        public BLLParcelasCompra(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ValidaCampos(ModeloParcelasCompra modelo)
        {
            if(modelo.parcelascompra == null)
            {
                throw new Exception("parcelascompra");
            }
        }
        public void ParcelaCadastraAtualiza(ModeloParcelasCompra modelo)
        {
            ValidaCampos(modelo);
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            DALObj.ParcelaCadastraAtualiza(modelo);
        }
        public void EfetuaPagamentoParcela(int comcod, int pcocod, DateTime dtppagto)
        {
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            DALObj.EfetuaPagamentoParcela(comcod, pcocod, dtppagto);
        }
        public void Alterar(ModeloParcelasCompra modelo)
        {
            ValidaCampos(modelo);
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
        }
        public void Excluir(ModeloParcelasCompra modelo)
        {
            double pcovalor = modelo.pco_valor;
            modelo.pco_valor = 0;
            ValidaCampos(modelo);
            modelo.pco_valor = pcovalor;
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            DALObj.Excluir(modelo);
        }
        public void ExcluirTodasParcelas(int comcod)
        {
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            DALObj.ExcluirTodasParcelas(comcod);
        }
        public DataTable Localizar(int cod)
        {
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            return DALObj.Localizar(cod);
        }
        public ModeloParcelasCompra CarregaModeloParcelasCompra(int procod, int comcod)
        {
            DALParcelasCompra DALObj = new DALParcelasCompra(conexao);
            return DALObj.CarregaModeloParcelasCompra(procod, comcod);
        }
    }
}
