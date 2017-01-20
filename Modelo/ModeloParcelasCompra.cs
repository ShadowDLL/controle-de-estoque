using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasCompra
    {
        public ModeloParcelasCompra()
        {
            pco_cod = 0;
            pco_valor = 0;
            pco_datapagto = DateTime.Now;
            pco_datavecto = DateTime.Now;
            com_cod = 0;
            parcelascompra = new DataTable();
            parcelascompra.Columns.Add("pco_valor", typeof(Double));
            parcelascompra.Columns.Add("pco_parcela");
            parcelascompra.Columns.Add("pco_datapagto", typeof(DateTime));
            parcelascompra.Columns.Add("pco_datavecto", typeof(DateTime));
            parcelascompra.Columns.Add("com_cod", typeof(Int32));
        }
        public ModeloParcelasCompra(int cod, double valor, DateTime pagto, DateTime vecto, int comcod)
        {
            pco_cod = cod;
            pco_valor = valor;
            pco_datapagto = pagto;
            pco_datavecto = vecto;
            com_cod = comcod;
        }
        public int pco_cod { get; set; }
        public double pco_valor { get; set; }
        public DateTime pco_datapagto { get; set; }
        public DateTime pco_datavecto { get; set; }
        public int com_cod { get; set; }
        public DataTable parcelascompra { get; set; }
    }
}
