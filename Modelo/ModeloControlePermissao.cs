using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloControlePermissao
    {
        public ModeloControlePermissao()
        {
            per_cod = 0;
            usu_cod = 0;
            per_nome = "";
        }
        public ModeloControlePermissao(int percod, int usucod, string nome)
        {
            per_cod = percod;
            usu_cod = usucod;
            per_nome = nome;
        }
        public static DataTable per_permissoes { get; set; }
        public int per_cod { get; set; }
        public int usu_cod { get; set; }
        public string per_nome { get; set; }

    }
}
