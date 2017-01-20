using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCompra
    {
        public ModeloCompra()
        {
            com_cod = 0;
            com_data = DateTime.Now;
            com_nfiscal = 0;
            com_total = 0;
            com_nparcelas = 0; 
            for_cod = 0;
            tpa_cod = 0;
        }
        public ModeloCompra(int cod, DateTime data, Double nfiscal, double total, int nparcelas, int forCod, int tpaStatus)
        {
            com_cod = cod;
            com_data = data;
            com_nfiscal = nfiscal;
            com_total = total;
            com_nparcelas = nparcelas; 
            for_cod = forCod;
            tpa_cod = tpaStatus;
        }
        public int com_cod { get; set; }
        public DateTime com_data { get; set; }
        public Double com_nfiscal { get; set; }
        public double com_total { get; set; }
        public int com_nparcelas { get; set; }
        public string com_status { get; set; }
        public int for_cod { get; set; }
        public int tpa_cod { get; set; }

    }
}
