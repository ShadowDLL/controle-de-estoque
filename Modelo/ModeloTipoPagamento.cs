using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloTipoPagamento
    {
        public ModeloTipoPagamento()
        {
            tpa_cod = 0;
            tpa_nome = "";
        }
        public ModeloTipoPagamento(int cod, string nome)
        {
            this.tpa_cod = cod;
            this.tpa_nome = nome;
        }
        public int tpa_cod { get; set; }
        public string tpa_nome { get; set; }
    }
}
