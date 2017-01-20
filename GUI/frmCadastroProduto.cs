using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using Modelo;
using System.IO;
using System.Data.SqlClient;

namespace GUI
{
    public partial class frmCadastroProduto : Form
    {
        #region "Variáveis"
        private const string caminhofoto = @"foto\FotoImage.png";
        private string foto = "";
        public int codigo { get; set; }
        #endregion

        #region "Eventos"
        public frmCadastroProduto()
        {
            InitializeComponent();
        }
        private void frmProduto_Load(object sender, EventArgs e)
        {
            CarregaCategoria();
            CarregaSubCategoria();
            CarregaUnidadeMedida();
            if (codigo != 0)
            {
                LocalizarProduto();
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
                BLLProduto bll = new BLLProduto(cx);
                ModeloProduto modelo = bll.CarregaModeloProduto(codigo);
                PreencheCampos(modelo);
            }
            else
            {
                frmConsultaProduto f = new frmConsultaProduto();
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
                    BLLProduto bll = new BLLProduto(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));             
                    Mensagem("PRODUTO EXCLUIDO ", Color.Blue);
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
                //Leitura dos dados
                ModeloProduto modelo = new ModeloProduto()
                {
                    ProNome = txtNome.Text,
                    ProDescricao = txtDescricao.Text,
                    ProValorPago = Convert.ToDouble(txtValorPago.Text),
                    ProValorVenda = Convert.ToDouble(txtValorVenda.Text),
                    ProQtde = Convert.ToDouble(txtQuantidade.Text),
                    UmedCod = Convert.ToInt32(cbxUnidadeMedida.SelectedValue),
                    CatCod = Convert.ToInt32(cbxCategoria.SelectedValue),
                    ScatCod = Convert.ToInt32(cbxSubCategoria.SelectedValue),
                };
                //Objeto para gravar os dados no banco
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLProduto bll = new BLLProduto(cx);
                if (txtCodigo.Text == "")
                {
                    //Cadastrar produto
                    modelo.CarregaImagem(foto);
                    bll.Inserir(modelo);
                    Mensagem("PRODUTO INSERIDO, CÓDIGO: " + modelo.ProCod.ToString(), Color.Blue);
                }
                else
                {
                    //Alterar um produto
                    modelo.ProCod = Convert.ToInt32(txtCodigo.Text);
                    if (foto == "Foto Original")
                    {
                        ModeloProduto mt = bll.CarregaModeloProduto(modelo.ProCod);
                        modelo.ProFoto = mt.ProFoto;
                    }
                    else
                    {
                        modelo.CarregaImagem(foto);
                    }
                    bll.Alterar(modelo);
                    Mensagem("PRODUTO ALTERADO ", Color.Blue);
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
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQuantidade.Clear();
            foto = "";
            picFoto.Image = null;
        }
        private void PreencheCampos(ModeloProduto modelo)
        {
            txtCodigo.Text = modelo.ProCod.ToString();
            txtNome.Text = modelo.ProNome;
            txtDescricao.Text = modelo.ProDescricao;
            txtValorPago.Text = modelo.ProValorPago.ToString();
            txtValorVenda.Text = modelo.ProValorVenda.ToString();
            txtQuantidade.Text = modelo.ProQtde.ToString();
            cbxUnidadeMedida.SelectedValue = modelo.UmedCod;
            cbxCategoria.SelectedValue = modelo.CatCod;
            cbxSubCategoria.SelectedValue = modelo.ScatCod;
            try
            {
                MemoryStream ms = new MemoryStream(modelo.ProFoto);
                picFoto.Image = Image.FromStream(ms);
                foto = "Foto Original";
            }
            catch { }
        }
        public void LocalizarProduto()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLProduto bll = new BLLProduto(cx);
            ModeloProduto modelo = bll.CarregaModeloProduto(codigo);
            PreencheCampos(modelo);
            alteraBotoes();
        }
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "nome":
                    txtNome.Focus();
                    Mensagem("DIGITE O NOME DO PRODUTO", Color.Red);
                    break;
                case "descricao":
                    txtDescricao.Focus();
                    Mensagem("DIGITE A DESCRIÇÃO DO PRODUTO", Color.Red);
                    break;
                case "valorpago":
                    txtValorPago.Focus();
                    Mensagem("DIGITE O VALOR PAGO DO PRODUTO", Color.Red);
                    break;
                case "valorvenda":
                    txtValorVenda.Focus();
                    Mensagem("DIGITE O VALOR DA VENDA DO PRODUTO", Color.Red);
                    break;
                case "umedcod":
                    cbxUnidadeMedida.Focus();
                    Mensagem("SELECIONE A UNIDADE DE MEDIDA DO PRODUTO", Color.Red);
                    break;
                case "catcod":
                    cbxCategoria.Focus();
                    Mensagem("SELECIONE CATEGORIA DO PRODUTO", Color.Red);
                    break;
                case "scatcod":
                    cbxSubCategoria.Focus();
                    Mensagem("SELECIONE A SUB CATEGORIA DO PRODUTO", Color.Red);
                    break;
                default:
                    Mensagem("ERRO AO REALIZAR O PROCEDIMENTO ", Color.Red);
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
        private void CarregaCategoria()
        {
            //combo categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCategoria bll = new BLLCategoria(cx);
            cbxCategoria.DataSource = bll.Localizar("");
            cbxCategoria.DisplayMember = "NOME";
            cbxCategoria.ValueMember = "CODIGO";
        }
        private void CarregaSubCategoria()
        {
            try
            {
                //combo sub categoria
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbxSubCategoria.DataSource = sbll.LocalizarPorCategoria(Convert.ToInt32(cbxCategoria.SelectedValue));
                cbxSubCategoria.DisplayMember = "NOME_SUBCATEGORIA";
                cbxSubCategoria.ValueMember = "CODIGO_SUBCATEGORIA";
            }
            catch (Exception erro)
            {
                Erro("CADASTRE UMA CATEGORIA " + erro.Message);
            }
        }
        private void CarregaUnidadeMedida()
        {
            //combo unidade de medida
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUnidadeMedida ubll = new BLLUnidadeMedida(cx);
            cbxUnidadeMedida.DataSource = ubll.Localizar("");
            cbxUnidadeMedida.DisplayMember = "Nome";
            cbxUnidadeMedida.ValueMember = "Codigo";
        }
        private void CarregaFoto()
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (od.FileName != "")
            {
                foto = od.FileName;
                picFoto.Load(foto);
            }
            else
            {
                picFoto.Load(caminhofoto);
            }
        }
        #endregion

        #region "Otimização"
        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCategoria bll = new BLLCategoria(cx);
            cbxCategoria.DataSource = bll.Localizar("");
            cbxCategoria.DisplayMember = "NOME";
            cbxCategoria.ValueMember = "CODIGO";
            try
            {
                //combo sub categoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbxSubCategoria.DataSource = sbll.LocalizarPorCategoria(Convert.ToInt32(cbxCategoria.SelectedValue));
                cbxSubCategoria.DisplayMember = "NOME";
                cbxSubCategoria.ValueMember = "CODIGO";
            }
            catch
            {
                MessageBox.Show("Cadastre uma categoria");
            }
        }
        private void btnAddUnidadeMedida_Click(object sender, EventArgs e)
        {
            frmCadastroUnidadeMedida f = new frmCadastroUnidadeMedida();
            f.ShowDialog();
            f.Dispose();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUnidadeMedida ubll = new BLLUnidadeMedida(cx);
            cbxUnidadeMedida.DataSource = ubll.Localizar("");
            cbxUnidadeMedida.DisplayMember = "NOME";
            cbxUnidadeMedida.ValueMember = "Codigo";

        }
        private void btnAddSubCategoria_Click(object sender, EventArgs e)
        {
            frmCadastroSubCategoria f = new frmCadastroSubCategoria();
            f.ShowDialog();
            f.Dispose();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            try
            {
                //combo sub categoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbxSubCategoria.DataSource = sbll.LocalizarPorCategoria(Convert.ToInt32(cbxCategoria.SelectedValue));
                cbxSubCategoria.DisplayMember = "NOME";
                cbxSubCategoria.ValueMember = "CODIGO";
            }
            catch
            {
                Erro("CADASTRE UMA SUB CATEGORIA");
            }
        }
        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(",") == false)
            {
                txtValorVenda.Text += ",00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(",") == txtValorVenda.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {

                txtValorVenda.Text = "0,00";
            }
        }
        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(",") == false)
            {
                txtValorPago.Text += ",00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(",") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {

                txtValorPago.Text = "0,00";
            }
        }
        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQuantidade.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Contains(",") == false)
            {
                txtQuantidade.Text += ",00";
            }
            else
            {
                if (txtQuantidade.Text.IndexOf(",") == txtQuantidade.Text.Length - 1)
                {
                    txtQuantidade.Text += "00";
                }
            }
            try
            {
                double d = Convert.ToDouble(txtQuantidade.Text);
            }
            catch
            {

                txtQuantidade.Text = "0,00";
            }
        }
        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combo categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            try
            {
                //combo sub categoria
                cbxSubCategoria.Text = "";
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbxSubCategoria.DataSource = sbll.LocalizarPorCategoria(Convert.ToInt32(cbxCategoria.SelectedValue));
                cbxSubCategoria.DisplayMember = "NOME";
                cbxSubCategoria.ValueMember = "CODIGO";
            }
            catch
            {
                Erro("CADASTRE UMA CATEGORIA");
            }
        }
        private void btnRemoverFoto_Click(object sender, EventArgs e)
        {
            picFoto.Load(caminhofoto);
        }
        private void pnFoto_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
        private void pnFoto_DragDrop(object sender, DragEventArgs e)
        {
            string[] arquivos = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (arquivos != null && arquivos.Any())
            {
                picFoto.Load(arquivos.First());
                foto = picFoto.ImageLocation;
            }
        }
        private void picFoto_MouseClick(object sender, MouseEventArgs e)
        {
            CarregaFoto();
        }
        #endregion
    }
}
