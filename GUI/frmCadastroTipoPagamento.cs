using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using BLL;
using DAL;
using System.Data.SqlClient;

namespace GUI
{
    public partial class frmCadastroTipoPagamento : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        #endregion

        #region "Eventos"
        public frmCadastroTipoPagamento()
        {
            InitializeComponent();
        }
        private void frmCadastroTipoPagamento_Load(object sender, EventArgs e)
        {
            if (codigo != 0)
            {
                LocalizarTipoPagamento();
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
                BLLTipoPagamento bll = new BLLTipoPagamento(cx);
                ModeloTipoPagamento modelo = bll.CarregaModeloTipoPagamento(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                frmConsultaTipoPagamento f = new frmConsultaTipoPagamento();
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
                    BLLTipoPagamento bll = new BLLTipoPagamento(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    Mensagem("TIPO DO PAGAMENTO EXCLUIDO ", Color.Blue);
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
                //Carrega os dados para o objeto de transferência
                ModeloTipoPagamento modelo = new ModeloTipoPagamento();
                modelo.tpa_nome = txtNome.Text;
                //Cria um BLL 
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLTipoPagamento bll = new BLLTipoPagamento(cx);
                if (txtCodigo.Text == "")
                {
                    bll.Inserir(modelo);
                    Mensagem("TIPO DO PAGAMENTO INSERIDO, CÓDIGO: " + modelo.tpa_cod.ToString(), Color.Blue);
                }
                else
                {
                    modelo.tpa_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    Mensagem("TIPO DO PAGAMENTO ALTERADO ", Color.Blue);
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
        private void PreencheCampos(ModeloTipoPagamento modelo)
        {
            txtCodigo.Text = modelo.tpa_cod.ToString();
            txtNome.Text = modelo.tpa_nome;
        }
        public void LocalizarTipoPagamento()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLTipoPagamento bll = new BLLTipoPagamento(cx);
            ModeloTipoPagamento modelo = bll.CarregaModeloTipoPagamento(codigo);
            PreencheCampos(modelo);
            alteraBotoes();
        }
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "nome":
                    txtNome.Focus();
                    Mensagem("DIGITE O NOME DO TIPO DO PAGAMENTO", Color.Red);
                    break;
                default:
                    Mensagem("ERRO AO EXCLUIR O TIPO DO PAGAMENTO ", Color.Red);
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
