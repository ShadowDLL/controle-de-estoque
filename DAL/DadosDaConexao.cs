using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static string servidor { get; set; }
        public static string banco { get; set; }
        public static string usuario { get; set; }
        public static string senha { get; set; }

        public static String StringDeConexão
        {
            get
            {
                return @"Data Source="+servidor+";Initial Catalog="+ banco+";User ID="+usuario+";Password="+senha;
            }
        }
    }
}
