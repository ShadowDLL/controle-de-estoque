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
    public class BLLItensCompra
    {
        private DALConexao conexao;
        public BLLItensCompra(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void ValidaCampos(ModeloItensCompra modelo)
        {
            if (modelo.itenscompra == null)
            {
                throw new Exception("itenscompra");
            }
        }
        public void ItensCadastrarAtualizar(ModeloItensCompra modelo)
        {
            ValidaCampos(modelo);
            DALItensCompra DALObj = new DALItensCompra(conexao);
            DALObj.ItensCadastrarAtualizar(modelo);
        }
        public void Alterar(ModeloItensCompra modelo)
        {
            ValidaCampos(modelo);
            DALItensCompra DALObj = new DALItensCompra(conexao);
            DALObj.Alterar(modelo);
        }
        public void Excluir(ModeloItensCompra modelo)
        {
            DALItensCompra DALObj = new DALItensCompra(conexao);
            DALObj.Excluir(modelo);
        }
        public void ExcluirTodosItens(int cod)
        {
            DALItensCompra DALObj = new DALItensCompra(conexao);
            DALObj.ExcluirTodosItens(cod);
        }
        public DataTable Localizar(int cod)
        {
            DALItensCompra DALObj = new DALItensCompra(conexao);
            return DALObj.Localizar(cod);
        }
        public ModeloItensCompra CarregaModeloItensCompra(int ItcCod, int ComCod, int ProCod)
        {
            DALItensCompra DALObj = new DALItensCompra(conexao);
            return DALObj.CarregaModeloItensCompra(ItcCod, ComCod, ProCod);
        }
    }
}

