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
    class BLLParcelasVenda
    {
        private DALConexao conexao;
        public BLLParcelasVenda(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ValidaCampos(ModeloParcelasVenda modelo)
        {
            if(modelo.ven_cod <= 0)
            {
                throw new Exception("O código da parcela é obrigatório");
            }
            if(modelo.pve_cod <= 0)
            {
                throw new Exception("O código da compra é obrigatório");
            }
            if (modelo.pve_valor == 0)
            {
                return;
            }
            if(modelo.pve_valor <= 0)
            {
                throw new Exception("O valor da parcela é obrigatório");
            }
            DateTime data = new DateTime();
            if (modelo.pve_datavecto.Year < data.Year)
            {
                throw new Exception("O ano de vencimento é inferior ao atual");
            }
        }
        public void Inserir(ModeloParcelasVenda modelo)
        {
            ValidaCampos(modelo);
            DALParcelasVenda DALObj = new DALParcelasVenda(conexao);
        }
        public void Alterar(ModeloParcelasVenda modelo)
        {
            ValidaCampos(modelo);
            DALParcelasVenda DALObj = new DALParcelasVenda(conexao);
        }
        public void Excluir(ModeloParcelasVenda modelo)
        {
            double pvevalor = modelo.pve_valor;
            modelo.pve_valor = 0;
            ValidaCampos(modelo);
            modelo.pve_valor = pvevalor;
            DALParcelasVenda DALObj = new DALParcelasVenda(conexao);
            DALObj.Excluir(modelo);
        }
        public void ExcluirTodasParcelas(int vencod)
        {
            DALParcelasVenda DALObj = new DALParcelasVenda(conexao);
            DALObj.ExcluirTodasParcelas(vencod);
        }
        public DataTable Localizar(int cod)
        {
            DALParcelasVenda DALObj = new DALParcelasVenda(conexao);
            return DALObj.Localizar(cod);
        }
        public ModeloParcelasVenda CarregaModeloParcelasVenda(int ven_cod, int pve_cod)
        {
            DALParcelasVenda DALObj = new DALParcelasVenda(conexao);
            return DALObj.CarregaModeloParcelasVenda(ven_cod, pve_cod);
        }
    }
}
