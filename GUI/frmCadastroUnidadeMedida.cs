using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroUnidadeMedida : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        #endregion

        #region "Eventos"
        public frmCadastroUnidadeMedida()
        {
            InitializeComponent();
        }
        private void frmCadastroUnidadeMedida_Load(object sender, EventArgs e)
        {
            if (codigo != 0)
            {
                LocalizarUnidadeMedida();
                codigo = 0;
            }
            alteraBotoes();
            txtNome.Focus();
        }
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLUnidadeMedida bll = new BLLUnidadeMedida(cx);
                ModeloUnidadeMedida modelo = bll.CarregaModeloUnidadeMedida(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                frmConsultaUnidadeMedida f = new frmConsultaUnidadeMedida();
                Close();
                f.ShowDialog();
                f.Dispose();
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja realmente excluir o registro? ", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                try
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                    BLLUnidadeMedida bll = new BLLUnidadeMedida(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    Mensagem("UNIDADE DE MEDIDA EXCLUIDA ", Color.Blue);
                }
                catch (SqlException)
                {
                    Erro("");
                }
                LimpaTela();
                alteraBotoes();
                txtNome.Focus();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //Leitura de dados
                ModeloUnidadeMedida modelo = new ModeloUnidadeMedida();
                modelo.umed_nome = txtNome.Text;
                //Objeto para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLUnidadeMedida bll = new BLLUnidadeMedida(cx);
                if (txtCodigo.Text == "")
                {
                    bll.Incluir(modelo);
                    Mensagem("UNIDADE DE MEDIDA INSERIDA, CÓDIGO: " + modelo.umed_cod.ToString(), Color.Blue);
                }
                else
                {
                    modelo.umed_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    Mensagem("UNIDADE DE MEDIDA ALTERADA ", Color.Blue);
                }
                LimpaTela();
                alteraBotoes();
            }
            catch (Exception erro)
            {
                Erro(erro.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
            alteraBotoes();
            txtNome.Focus();
        }
        #endregion

        #region "Funções"
        private void alteraBotoes()
        {
            btnExcluir.Enabled = (txtCodigo.Text.Trim().Length < 1) ? false : true;
        }
        public void LimpaTela()
        {
            //Limpar a tela
            txtCodigo.Clear();
            txtNome.Clear();
        }
        private void PreencheCampos(ModeloUnidadeMedida modelo)
        {
            txtCodigo.Text = modelo.umed_cod.ToString();
            txtNome.Text = modelo.umed_nome;
        }
        public void LocalizarUnidadeMedida()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUnidadeMedida bll = new BLLUnidadeMedida(cx);
            ModeloUnidadeMedida modelo = bll.CarregaModeloUnidadeMedida(codigo);
            PreencheCampos(modelo);
            alteraBotoes();
        }
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "nome":
                    txtNome.Focus();
                    Mensagem("DIGITE O NOME DA UNIDADE DE MEDIDA", Color.Red);
                    break;
                default:
                    Mensagem("ERRO AO EXCLUIR A UNIDADE DE MEDIDA POIS ESTA SENDO UTILIZADO EM OUTRO REGISTRO ", Color.Red);
                    break;
            }
        }
        private void Mensagem(string mensagem, Color cor)
        {
            tssMensagem.ForeColor = cor;
            tssMensagem.Text = mensagem;
            Refresh();
            System.Threading.Thread.Sleep(2000);
            tssMensagem.Text = "";
        }
        #endregion
    }
}
