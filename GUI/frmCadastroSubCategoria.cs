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
    public partial class frmCadastroSubCategoria : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        #endregion

        #region "Eventos"
        public frmCadastroSubCategoria()
        {
            InitializeComponent();
        }
        private void frmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            LocalizarCategoria();
            if (codigo != 0)
            {
                LocalizarSubCategoria();
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
                BLLSubCategoria bll = new BLLSubCategoria(cx);
                ModeloSubCategoria modelo = bll.CarregaModeloSubCategoria(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                frmConsultaSubCategoria f = new frmConsultaSubCategoria();
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
                    BLLSubCategoria bll = new BLLSubCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    Mensagem("SUB CATEGORIA EXCLUIDA ", Color.Blue);
                }
                catch (SqlException)
                {
                    Erro("ERRO AO EXCLUIR A SUB CATEGORIA POIS ESTA SENDO UTILIZADA EM OUTRO REGISTRO ");
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
                ModeloSubCategoria modelo = new ModeloSubCategoria();
                modelo.snome = txtNome.Text;
                modelo.cat_cod = Convert.ToInt32(cbxCategoria.SelectedValue);
                //Objeto para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLSubCategoria bll = new BLLSubCategoria(cx);
                if (txtCodigo.Text == "")
                {
                    //Cadastrar uma categoria
                    bll.Incluir(modelo);
                    Mensagem("SUB CATEGORIA INSERIDA, CÓDIGO: " + modelo.cat_cod.ToString(), Color.Blue);
                }
                else
                {
                    //Alterar uma categoria
                    modelo.scat_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    Mensagem("SUB CATEGORIA ALTERADA ", Color.Blue);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCategoria bll = new BLLCategoria(cx);
            cbxCategoria.DataSource = bll.Localizar("");
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
            cbxCategoria.Text = "";
            
        }
        private void PreencheCampos(ModeloSubCategoria modelo)
        {
            txtCodigo.Text = modelo.scat_cod.ToString();
            txtNome.Text = modelo.snome;
            cbxCategoria.SelectedValue = modelo.cat_cod;
        }
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "nome":
                    txtNome.Focus();
                    Mensagem("DIGITE O NOME DA SUB CATEGORIA", Color.Red);
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
        public void LocalizarSubCategoria()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLSubCategoria bll = new BLLSubCategoria(cx);
            ModeloSubCategoria modelo = bll.CarregaModeloSubCategoria(codigo);
            PreencheCampos(modelo);
            alteraBotoes();
        }
        public void LocalizarCategoria()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCategoria bll = new BLLCategoria(cx);
            cbxCategoria.DataSource = bll.Localizar("");
            cbxCategoria.ValueMember = "CODIGO";
            cbxCategoria.DisplayMember = "NOME";
        }
        #endregion

    }
}
