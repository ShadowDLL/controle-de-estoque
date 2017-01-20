using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUsuario
    {
        public ModeloUsuario()
        {
            usu_cod = 0;
            usu_nome = "";
            usu_cpf = "";
            usu_rg = "";
            end_cod = 0;
            usu_cep = "";
            usu_sgl = "";
            usu_estado = "";
            usu_cidade = "";
            usu_bairro = "";
            usu_logradouro = "";
            usu_numero = "";
            usu_complemento = "";
            usu_email = "";
            usu_telefone = "";
            usu_celular = "";
            usu_login = "";
            usu_senha = "";
            usu_lembretesenha = "";
        }
        public ModeloUsuario(int cod, string nome, string cpf, string rg, int endcod, string cep, string sgl,string estado, string cidade, string bairro, string logradouro, string numero, string usucomplemento, string email, string telefone,  string celular, string login, string senha, string lembretesenha)
        {
            usu_cod = cod;
            usu_nome = nome;
            usu_cpf = cpf;
            usu_rg = rg;
            end_cod = endcod; 
            usu_cep = cep;
            usu_sgl = sgl;
            usu_estado = estado; 
            usu_cidade = cidade;
            usu_bairro = bairro;
            usu_logradouro = logradouro;
            usu_numero = numero;
            usu_complemento = usucomplemento;
            usu_email = email;
            usu_telefone = telefone;
            usu_celular = celular;
            usu_login = login;
            usu_senha = senha;
            usu_lembretesenha = lembretesenha;
        }
        public int usu_cod { get; set; }
        public string usu_nome { get; set; }
        public string usu_cpf { get; set; }
        public string usu_rg { get; set; }
        public string usu_cep { get; set; }
        public int end_cod { get; set; }
        public string usu_estado { get; set; }
        public string usu_sgl { get; set; }
        public string usu_cidade { get; set; }
        public string usu_bairro { get; set; }
        public string usu_logradouro { get; set; }
        public string usu_numero { get; set; }
        public string usu_complemento { get; set; }
        public string usu_email { get; set; }
        public string usu_telefone { get; set; }
        public string usu_celular { get; set; }
        public string usu_login { get; set; }
        public string usu_senha { get; set; }
        public string usu_lembretesenha { get; set; }
    }
}
