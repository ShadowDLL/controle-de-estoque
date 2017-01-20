using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DAL;

namespace GUI
{
    public partial class frmConfiguracaoBancoDados : Form
    {
        public frmConfiguracaoBancoDados()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("ConfiguracaoBanco.txt", false);
                arquivo.WriteLine(txtServidor.Text);
                arquivo.WriteLine(txtBanco.Text);
                arquivo.WriteLine(txtUsuario.Text);
                arquivo.WriteLine(txtSenha.Text);
                arquivo.Close();
                MessageBox.Show("Arquivo Atualizado com sucesso!!!");
                this.Close();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        private void frmConfiguracaoBancoDados_Load(object sender, EventArgs e)
        {
            try
            {

                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                txtServidor.Text = arquivo.ReadLine();
                txtBanco.Text = arquivo.ReadLine();
                txtUsuario.Text = arquivo.ReadLine();
                txtSenha.Text = arquivo.ReadLine();
                arquivo.Close();
                //Testar a conexão
                SqlConnection conexao = new SqlConnection(DadosDaConexao.StringDeConexão);
                //conexao.ConnectionString = DadosDaConexao.StringDeConexão;
                conexao.Open();
                conexao.Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Erro ao se conectar no banco de dados \n" + "Acesse as configurações do banco de dados e informe os parâmetros de conexão" );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arquivo ainda não foi criado" + ex.Message );
                //throw new Exception(ex.Message);
            }

        }

        private void btnTestaConexao_Click(object sender, EventArgs e)
        {
            try
            {
                DadosDaConexao.servidor = txtServidor.Text;
                DadosDaConexao.banco = txtBanco.Text;
                DadosDaConexao.usuario = txtUsuario.Text;
                DadosDaConexao.senha = txtSenha.Text;
                //Testar a conexao
                SqlConnection conexao = new SqlConnection(DadosDaConexao.StringDeConexão);
                conexao.Open();
                conexao.Close();
                MessageBox.Show("Conexão efetuada com sucesso");
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro ao se conectar no banco de dados \n" + "Verifique os dados informados");
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message); 
            }


        }
    }
}
