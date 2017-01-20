using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCliente
    {
        public ModeloCliente()
        {
            cli_cod = 0;
            cli_nome = "";
            cli_cpfcnpj = "";
            cli_rgie = "";
            cli_rsocial = "";
            cli_tipo = "";
            end_cod = 0;
            cli_cep = "";
            cli_estado = "";
            cli_sgl = "";
            cli_cidade = "";
            cli_bairro = "";
            cli_logradouro = "";
            cli_numero = "";
            cli_complemento = "";
            cli_email = "";
            cli_telefone = "";
            cli_celular = "";
        }
        public ModeloCliente(int cod, string nome, string cpfcnpj, string rgie, string rsocial, string tipo, int endcod, string cep, string estado, string sgl, string cidade, string bairro, string logradouro, string numero, string complemento, string email, string telefone, string celular)
        {
            cli_cod = cod;
            cli_nome = nome;
            cli_cpfcnpj = cpfcnpj;
            cli_rgie = rgie;
            cli_rsocial = rsocial;
            cli_tipo = tipo;
            end_cod = endcod;
            cli_cep = cep;
            cli_estado = estado;
            cli_sgl = sgl;
            cli_cidade = cidade;
            cli_bairro = bairro;
            cli_logradouro = logradouro;
            cli_complemento = complemento;
            cli_email = email;
            cli_telefone = telefone;
            cli_celular = celular;
        }
        public int cli_cod { get; set; }
        public string cli_nome { get; set; }
        public string cli_cpfcnpj { get; set; }
        public string cli_rgie { get; set; }
        public string cli_rsocial { get; set; }
        public string cli_tipo { get; set; }
        public int end_cod { get; set; }
        public string cli_cep { get; set; }
        public string cli_estado { get; set; }
        public string cli_sgl { get; set; }
        public string cli_cidade { get; set; }
        public string cli_bairro { get; set; }
        public string cli_logradouro { get; set; }
        public string cli_numero { get; set; }
        public string cli_complemento { get; set; }
        public string cli_email { get; set; }
        public string cli_telefone { get; set; }
        public string cli_celular { get; set; }
    }
}
