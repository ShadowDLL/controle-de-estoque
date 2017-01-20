using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCategoria
    {
        public ModeloCategoria ()
        {
            this.cat_cod = 0;
            this.catnome = "";
        }
        public ModeloCategoria(int catcod, string catnome)
        {
            this.cat_cod = catcod;
            this.catnome = catnome;
        }
        public int cat_cod { get; set; }
        public string catnome { get; set; }
    }
}
