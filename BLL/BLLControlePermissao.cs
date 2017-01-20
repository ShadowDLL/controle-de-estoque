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
    public class BLLControlePermissao
    {
        private DALConexao conexao;
        public BLLControlePermissao(DALConexao cx)
        {
            this.conexao = cx;
        }
        private void ValidaCampos(ModeloControlePermissao modelo)
        {
            if (modelo.usu_cod <= 0)
            {
                throw new Exception("O código do usuário deve ser informado");
            }
            modelo.per_nome = modelo.per_nome.Trim().ToUpper();
	{	 
	}
        }
        public void Inserir(DataTable permissao, int usucod)
        {
            DALControlePermissao DALObj = new DALControlePermissao(conexao);
            DALObj.Inserir(permissao, usucod);
        }
        public DataTable Localizar(int usucod)
        {
            DALControlePermissao DALObj = new DALControlePermissao(conexao);
            return DALObj.Localizar(usucod);
        }
    }
}
