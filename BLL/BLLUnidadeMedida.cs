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
    public class BLLUnidadeMedida
    {
        private DALConexao conexao;
        public BLLUnidadeMedida(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloUnidadeMedida modelo)
        {
            if (modelo.umed_nome.Trim().Length == 0)
            {
                throw new Exception("nome");
            }
            modelo.umed_nome = modelo.umed_nome.ToUpper();
        }
        public void Incluir(ModeloUnidadeMedida modelo)
        {
            ValidaCampos(modelo);
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloUnidadeMedida modelo)
        {
            ValidaCampos(modelo);
            if(modelo.umed_cod <= 0)
            {
                throw new Exception("código");
            }
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable Localizar(string valor)
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloUnidadeMedida CarregaModeloUnidadeMedida(int codigo)
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            return DALobj.CarregaUnidadeMedida(codigo);
        }
        public int VerificaUnidadeMedida(string valor)
        {
            DALUnidadeMedida DALobj = new DALUnidadeMedida(conexao);
            return DALobj.VerificaUnidadeMedida(valor);

        }
    }
}
