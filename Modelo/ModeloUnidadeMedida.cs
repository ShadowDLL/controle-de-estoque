using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUnidadeMedida
    {
        public ModeloUnidadeMedida ()
        {
            this.umed_cod = 0;
            this.umed_nome = "";
        }
        public ModeloUnidadeMedida(int umdcod, string umdnome)
        {
            this.umed_cod = umdcod;
            this.umed_nome = umdnome;
        }
        public int umed_cod { get; set; }
        public string umed_nome { get; set; }
    }
}
