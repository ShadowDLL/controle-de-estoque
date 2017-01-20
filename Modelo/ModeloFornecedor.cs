using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloFornecedor
    {
        public ModeloFornecedor()
        {
            for_cod = 0;
            for_nome = "";
            for_rsocial = "";
            for_ie = "";
            for_cnpj = "";
            end_cod = 0;
            for_cep = "";
            for_estado = "";
            for_sgl = "";
            for_cidade = "";
            for_bairro = "";
            for_logradouro = "";
            for_numero = "";
            for_complemento = "";
            for_email = "";
            for_telefone = "";
            for_celular = "";
        }
        public ModeloFornecedor(int cod, string nome, string rsocial, string ie, string cnpj, int endcod, string cep, string estado, string sgl, string cidade, string bairro, string logradouro, string numero, string complemento, string email, string telefone, string celular )
        {
            for_cod = cod;
            for_nome = nome;
            for_rsocial = rsocial;
            for_ie = ie;
            for_cnpj = cnpj;
            end_cod = endcod;
            for_cep = cep;
            for_estado = estado;
            for_sgl = sgl;
            for_cidade = cidade;
            for_bairro = bairro;
            for_logradouro = logradouro;
            for_numero = numero;
            for_complemento = complemento;
            for_email = email;
            for_telefone = telefone;
            for_celular = celular;
        }
        public int for_cod { get; set; }
        public string for_nome { get; set; }
        public string for_rsocial { get; set; }
        public string for_ie { get; set; }
        public string for_cnpj { get; set; }
        public int end_cod { get; set; }
        public string for_cep { get; set; }
        public string for_estado { get; set; }
        public string for_sgl { get; set; }
        public string for_cidade { get; set; }
        public string for_bairro { get; set; }
        public string for_logradouro { get; set; }
        public string for_numero { get; set; }
        public string for_complemento { get; set; }
        public string for_email { get; set; }
        public string for_telefone { get; set; }
        public string for_celular { get; set; }
    }
}
