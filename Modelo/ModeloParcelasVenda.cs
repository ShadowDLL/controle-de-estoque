using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasVenda
    {
        public ModeloParcelasVenda()
        {
            ven_cod = 0;
            pve_cod = 0;
            pve_valor = 0;
            pve_datapagto = DateTime.Now;
            pve_datavecto = DateTime.Now;
        }
        public ModeloParcelasVenda(int cod, int pvecod, double valor, DateTime pagto, DateTime vecto)
        {
            ven_cod = cod;
            pve_cod = pvecod;
            pve_valor = valor;
            pve_datapagto = pagto;
            pve_datavecto = vecto;
        }
        public int ven_cod { get; set; }
        public double pve_valor { get; set; }
        public DateTime pve_datapagto { get; set; }
        public DateTime pve_datavecto { get; set; }
        public int pve_cod { get; set; }
    }
}

