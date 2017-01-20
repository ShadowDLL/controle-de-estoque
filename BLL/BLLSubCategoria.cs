using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLSubCategoria
    {
        private DALConexao conexao;
        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloSubCategoria modelo)
        {
            if (modelo.snome.Trim().Length == 0)
            {
                throw new Exception("nome");
            }
            modelo.snome = modelo.snome.ToUpper();
        }
        public void Incluir(ModeloSubCategoria modelo)
        {
            ValidaCampos(modelo);   
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloSubCategoria modelo)
        {
            if (modelo.cat_cod <= 0)
            {
                throw new Exception("código");
            }
            ValidaCampos(modelo); 
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Exluir(cod);
        }
        public DataTable Localizar (string valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }
        public DataTable LocalizarPorCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.LocalizarPorCategoria(codigo);
        }
        public ModeloSubCategoria CarregaModeloSubCategoria (int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);

        }
    }
}
