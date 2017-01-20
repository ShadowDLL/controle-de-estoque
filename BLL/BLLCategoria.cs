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
    public class BLLCategoria
    {
        private DALConexao conexao;
        public BLLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidarCampos(ModeloCategoria modelo)
        {
            if (modelo.catnome.Trim().Length == 0)
            {
                throw new Exception("nome");
            }
            modelo.catnome = modelo.catnome.ToUpper();
        }
        public void Incluir(ModeloCategoria modelo)
        {
            ValidarCampos(modelo);
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloCategoria modelo)
        {
            ValidarCampos(modelo);
            if (modelo.cat_cod <= 0)
            {
                throw new Exception("código");
            }
            modelo.catnome = modelo.catnome.ToUpper();
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int cod)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Exluir(cod);
        }
        public DataTable Localizar (string valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloCategoria CarregaModeloCategoria (int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregaModeloCategoria(codigo);

        }
    }
}
