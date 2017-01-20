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
using DAL;
using BLL;
using System.Data.SqlClient;
namespace GUI
{
    public partial class frmCadastroCategoria : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        #endregion

        #region "Eventos"
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }
        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            if (codigo != 0)
            {
                LocalizarCategoria();
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
                BLLCategoria bll = new BLLCategoria(cx);
                ModeloCategoria modelo = bll.CarregaModeloCategoria(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                frmConsultaCategoria f = new frmConsultaCategoria();
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
                    BLLCategoria bll = new BLLCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    Mensagem("CATEGORIA EXCLUIDA ", Color.Blue);
                }
                catch (SqlException)
                {
                    Erro("ERRO AO EXCLUIR A CATEGORIA POIS ESTA SENDO UTILIZADA EM OUTRO REGISTRO ");
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
                //Leitura dos dados;
                ModeloCategoria modelo = new ModeloCategoria();
                modelo.catnome = txtNome.Text;
                //Objeto para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLCategoria bll = new BLLCategoria(cx);
                if (txtCodigo.Text == "")
                {
                    //Cadastrar uma categoria
                    bll.Incluir(modelo);
                    Mensagem("CATEGORIA INSERIDA, CÓDIGO: " + modelo.cat_cod.ToString(), Color.Blue);
                }
                else
                {
                    //Alterar uma categoria
                    modelo.cat_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    Mensagem("CATEGORIA ALTERADA ", Color.Blue);
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
        private void LimpaTela()
        {
            //Limpar a tela
            txtCodigo.Clear();
            txtNome.Clear();
        }
        private void PreencheCampos(ModeloCategoria modelo)
        {
            txtCodigo.Text = modelo.cat_cod.ToString();
            txtNome.Text = modelo.catnome;
        }
        public void LocalizarCategoria()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCategoria bll = new BLLCategoria(cx);
            ModeloCategoria modelo = bll.CarregaModeloCategoria(codigo);
            PreencheCampos(modelo);
            alteraBotoes();
        }
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "nome":
                    txtNome.Focus();
                    Mensagem("DIGITE O NOME DA CATEGORIA", Color.Red);
                    break;
                default:
                    Mensagem(erro, Color.Red);
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

        #region "Otimização"
        private void frmCadastroCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }
        #endregion
    }
}
