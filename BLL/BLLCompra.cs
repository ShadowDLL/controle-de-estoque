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
    public class BLLCompra
    {
        private DALConexao conexao;
        public BLLCompra(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ValidaCampos(ModeloCompra modelo)
        {
            if (modelo.com_data < DateTime.Today)
            {
                throw new Exception("data");
            }
            if (modelo.com_nfiscal < 1)
            {
                throw new Exception("nfiscal");
            }
            if (modelo.com_total <= 0)
            {
                throw new Exception("total");
            }
            if (modelo.com_nparcelas <= 0)
            {
                throw new Exception("nparcelas");
            }
            if (modelo.for_cod == 0)
            {
                throw new Exception("for_cod");
            }
            if (modelo.tpa_cod == 0)
            {
                throw new Exception("tpa_cod");
            }
        }
        public void Inserir(ModeloCompra modelo)
        {
            ValidaCampos(modelo);
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.Inserir(modelo);
        }
        public void Alterar(ModeloCompra modelo)
        {
            if (modelo.com_cod <= 0)
            {
                throw new Exception("O código da compra deve ser informado");
            }
            ValidaCampos(modelo);
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.Excluir(cod);
        }
        public void Cancelar(int cod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.Cancelar(cod);
        }
        public DataTable Localizar(int for_cod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.Localizar(for_cod);
        }
        public DataTable Localizar(string nome)
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.Localizar(nome);
        }
        public DataTable Localizar()
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.Localizar();
        }
        public DataTable LocalizarParcelasEmAberto()
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.LocalizarParcelasEmAberto();
        }
        public DataTable Localizar(DateTime dataInicial, DateTime dataFinal)
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.Localizar(dataInicial, dataFinal);
        }
        public ModeloCompra CarregaModeloCompra(int cod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.CarregaModeloCompra(cod);
        }
        public int QuantidadeParcelasNaoPagas(int comcod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            return DALObj.QuantidadeParcelasNaoPagas(comcod);
        }
        public void ParcelasCompraPagar (int comcod, int pcocod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.ParcelasCompraPagar(comcod, pcocod);
        }
        public void ParcelasCompraCancelar(int comcod, int pcocod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.ParcelasCompraCancelar(comcod, pcocod);
        }
        public void AtualizaStatusCompra(int comcod)
        {
            DALCompra DALObj = new DALCompra(conexao);
            DALObj.AtualizaStatusCompra(comcod);
        }
    }
}
