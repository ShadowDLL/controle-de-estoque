using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloItensCompra
    {
        public ModeloItensCompra()
        {
            itc_cod = 0;
            itc_qtde = 0;
            itc_valor = 0;
            com_cod = 0;
            pro_cod = 0;
            itenscompra = new DataTable();
            itenscompra.Columns.Add("itc_qtde", typeof(Int32));
            itenscompra.Columns.Add("itc_valor", typeof(Double));
            itenscompra.Columns.Add("com_cod", typeof(Int32));
            itenscompra.Columns.Add("pro_cod", typeof(Int32));
        }
        public ModeloItensCompra(int cod, double qtde, double valor, int comcod, int procod)
        {
            itc_cod = cod;
            itc_qtde = qtde;
            itc_valor = valor;
            com_cod = comcod;
            pro_cod = procod;
        }
        public int itc_cod { get; set; }
        public double itc_qtde { get; set; }
        public double itc_valor { get; set; }
        public int com_cod { get; set; }
        public int pro_cod { get; set; }
        public DataTable itenscompra { get; set; }
    }
}
