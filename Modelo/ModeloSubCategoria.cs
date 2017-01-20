using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloSubCategoria
    {
        public ModeloSubCategoria ()
        {
            this.cat_cod = 0;
            this.scat_cod = 0;
            this.snome = "";
        }
        public ModeloSubCategoria(int catcod, int scatcod, string snome)
        {
            this.cat_cod = catcod;
            this.scat_cod = scatcod;
            this.snome = snome;
        }
        public int cat_cod { get; set; }
        public int scat_cod { get; set; }
        public string snome { get; set; }
    }
}
