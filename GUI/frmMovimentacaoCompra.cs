using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using Modelo;
using Ferramentas;

namespace GUI
{
    public partial class frmMovimentacaoCompra : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        public double totalCompra = 0;
        private DataTable produto;
        private bool carregaComboBox;
        #endregion

        #region "Eventos"
        public frmMovimentacaoCompra()
        {
            InitializeComponent();
        }
        private void frmMovimentacaoCompra_Load(object sender, EventArgs e)
        {
            CarregaComboBox();
            ValorUnitario();
            if (codigo != 0)
            {
                LocalizarCompra();
            }
            alteraBotoes();
            Avancar();
            txtNFiscal.Focus();
        }
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaCompra f = new frmConsultaCompra();
            Close();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Deseja realmente cancelar a compra? ", "Aviso", MessageBoxButtons.YesNo);
            if (r.ToString() == "Yes")
            {
                try
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                    BLLCompra bll = new BLLCompra(cx);
                    bll.Cancelar(codigo);
                    Mensagem("COMPRA CANCELADA ", Color.Blue);
                    LimpaTela();
                    alteraBotoes();
                }
                catch (Exception erro)
                {
                    if (erro.Message == "An invalid parameter or option was specified for procedure 'parcelas'.")
                    {
                        Erro("parcelas");
                    }
                    else
                    {
                        Erro(erro.Message);
                    }
                }
            }
        }
        private void btnAvancar_Click(object sender, EventArgs e)
        {
            dgvParcelas.Rows.Clear();
            DateTime data = dtpDataInicialPagamento.Value;
            while (data.Day >= 28)
            {
                data = data.AddDays(1);
            }
            Double totalItens = Convert.ToDouble(lblTotalItens.Text);
            int numParcelas = Convert.ToInt32(nudNumeroParcelas.Value);
            Double valorParcela = totalItens / numParcelas;
            for (int i = 1; i <= nudNumeroParcelas.Value; i++)
            {
                String[] linha = new String[] { i.ToString() + "/" + nudNumeroParcelas.Value, valorParcela.ToString("#.00"), data.Date.ToShortDateString() };
                this.dgvParcelas.Rows.Add(linha);
                data = data.AddMonths(1);
            }
            lblTotalCompra.Text = lblTotalItens.Text;
            pnFinalizaCompra.Visible = true;
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            alteraBotoes();
            LimpaTela();
        }
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            if ((cbxProduto.Text != "") && (nudQuantidade.Text != "") && (lblValorUnitario.Text != ""))
            {
                this.totalCompra = 0;
                bool produto = false;
                double TotalLocal = Convert.ToDouble(nudQuantidade.Text) * Convert.ToDouble(lblValorUnitario.Text);
                //Verifica se já existe o item no grid
                if (dgvItensCompra.RowCount > 0)
                {
                    int codProduto = Convert.ToInt32(cbxProduto.SelectedValue);
                    for (int i = 0; i < dgvItensCompra.RowCount; i++)
                    {
                        int celula = Convert.ToInt32(dgvItensCompra.Rows[i].Cells[0].Value);
                        if (celula == codProduto)
                        {
                            dgvItensCompra.Rows[i].Cells[2].Value = nudQuantidade.Value;
                            dgvItensCompra.Rows[i].Cells[4].Value = TotalLocal.ToString("#0.00");
                            produto = true;
                            break;
                        }
                    }
                    //Adiciona o item caso não exista no grid
                    if (!produto)
                    {
                        String[] linha = new String[] { cbxProduto.SelectedValue.ToString(), cbxProduto.Text, nudQuantidade.Text, lblValorUnitario.Text, TotalLocal.ToString("#.00") };
                        this.dgvItensCompra.Rows.Add(linha);
                    }
                }
                //Adiciona o item caso não exista nenhum registro
                else
                {
                    String[] linha = new String[] { cbxProduto.SelectedValue.ToString(), cbxProduto.Text, nudQuantidade.Text, lblValorUnitario.Text, TotalLocal.ToString() };
                    this.dgvItensCompra.Rows.Add(linha);
                }
                //Soma os valores adicionados no grid
                for (int i = 0; i < dgvItensCompra.RowCount; i++)
                {
                    this.totalCompra += Convert.ToDouble(dgvItensCompra.Rows[i].Cells[4].Value);
                }
                cbxProduto.SelectedIndex = 0;
                nudQuantidade.Value = 1;
                lblTotalItens.Text = totalCompra.ToString("#.00");
            }
            Avancar();
        }
        private void btnCancelarPagamento_Click(object sender, EventArgs e)
        {
            dgvParcelas.Rows.Clear();
            pnFinalizaCompra.Visible = false;
        }
        private void btnSalvarPagamento_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            cx.Conectar();
            cx.IniciaTransacao();
            try
            {
                //Leitura de dados
                ModeloCompra modeloCompra = new ModeloCompra()
                {
                    com_data = DateTime.Now,
                    com_nfiscal = Convert.ToInt32(txtNFiscal.Text),
                    com_total = Convert.ToDouble(lblTotalCompra.Text),
                    com_nparcelas = Convert.ToInt32(nudNumeroParcelas.Text),
                    for_cod = Convert.ToInt32(cbxFornecedor.SelectedValue),
                    tpa_cod = Convert.ToInt32(cbxTipoPagamento.SelectedValue)
                };
                //Objeto para gravar dados no banco
                BLLCompra bll = new BLLCompra(cx);
                //Cria o objeto Itens
                ModeloItensCompra mItens = new ModeloItensCompra();
                BLLItensCompra bItens = new BLLItensCompra(cx);
                //Cria o objeto parcelas
                ModeloParcelasCompra mParcelas = new ModeloParcelasCompra();
                BLLParcelasCompra bParcelas = new BLLParcelasCompra(cx);
                if (txtCodigo.Text == "")
                {
                    bll.Inserir(modeloCompra);
                    CadastrarItensCompra(mItens, modeloCompra, bItens, mParcelas, bParcelas);
                    Mensagem("COMPRA EFETUADA: CÓDIGO: " + modeloCompra.com_cod.ToString(), Color.Blue);
                }
                else
                {
                    modeloCompra.com_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modeloCompra);
                    CadastrarItensCompra(mItens, modeloCompra, bItens, mParcelas, bParcelas);
                    Mensagem("COMPRA ALTERADA ", Color.Blue);
                }
                LimpaTela();
                alteraBotoes();
                pnFinalizaCompra.Visible = false;
                cx.FinalizaTransacao();
            }
            catch (Exception erro)
            {
                cx.CancelaTransacao();
                if (erro.Message == "An invalid parameter or option was specified for procedure 'parcelas'.")
                {
                    Erro("parcelas");
                }
                else
                {
                    Erro(erro.Message);
                }
            }
            finally
            {
                cx.Desconectar();
            }
        }
        private void dgvItensCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                carregaComboBox = false;
                cbxProduto.SelectedValue = dgvItensCompra.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbxProduto.Text = dgvItensCompra.Rows[e.RowIndex].Cells[1].Value.ToString();
                nudQuantidade.Text = dgvItensCompra.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblValorUnitario.Text = dgvItensCompra.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.totalCompra = Convert.ToDouble(lblTotalItens.Text) - Convert.ToDouble(dgvItensCompra.Rows[e.RowIndex].Cells[4].Value);
                dgvItensCompra.Rows.RemoveAt(e.RowIndex);
                lblTotalItens.Text = this.totalCompra.ToString("#0.00");
                carregaComboBox = true;
                btnAvancar.Enabled = dgvItensCompra.RowCount > 0 ? true : false;
            }
        }
        private void cbxTipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoPagamento.Text == "À VISTA")
            {
                nudNumeroParcelas.Enabled = false;
                nudNumeroParcelas.Value = 1;
            }
            else
            {
                nudNumeroParcelas.Enabled = true;
                nudNumeroParcelas.Value = 2;
            }
        }
        private void btnAdicionaFornecedor_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedor f = new frmCadastroFornecedor();
            f.ShowDialog();
            f.Dispose();
            CarregaFornecedor();
        }
        private void btnProduto_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto();
            f.ShowDialog();
            f.Dispose();
            CarregaProduto();
            ValorUnitario();
        }
        private void btnAdicionaProduto_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto();
            f.ShowDialog();
            f.Dispose();
            CarregaProduto();
        }
        private void txtNFiscal_KeyUp(object sender, KeyEventArgs e)
        {
            Avancar();
        }
        private void txtNFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void cbxFornecedor_Leave(object sender, EventArgs e)
        {
            if (cbxFornecedor.SelectedValue == null)
            {
                cbxFornecedor.Focus();
            }
        }
        private void cbxProduto_Leave(object sender, EventArgs e)
        {
            if (cbxProduto.SelectedValue == null)
            {
                cbxProduto.Focus();
            }
        }
        private void btnTipoPagamento_Click(object sender, EventArgs e)
        {
            frmCadastroTipoPagamento f = new frmCadastroTipoPagamento();
            f.ShowDialog();
            f.Dispose();
            CarregaTipoPagamento();
        }
        #endregion

        #region "Funçoes"
        private void alteraBotoes()
        {
            btnCancelar.Enabled = (txtCodigo.Text.Trim().Length < 1) ? false : true;
        }
        private void LimpaTela()
        {
            txtCodigo.Clear();
            txtNFiscal.Clear();
            cbxFornecedor.SelectedIndex = 0;
            cbxProduto.SelectedIndex = 0;
            nudQuantidade.Value = 1;
            dgvItensCompra.Rows.Clear();
            cbxTipoPagamento.SelectedIndex = 0;
            dtpDataInicialPagamento.Value = DateTime.Now;
            lblTotalItens.Text = "0,00";
            totalCompra = 0;
            txtNFiscal.Clear();
        }
        public void LocalizarCompra()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCompra bll = new BLLCompra(cx);
            ModeloCompra modelo = bll.CarregaModeloCompra(codigo);
            txtCodigo.Text = modelo.com_cod.ToString();
            txtNFiscal.Text = modelo.com_nfiscal.ToString();
            cbxFornecedor.SelectedValue = modelo.for_cod;
            cbxTipoPagamento.SelectedValue = modelo.tpa_cod;
            nudNumeroParcelas.Value = modelo.com_nparcelas;
            dtpDataInicialPagamento.Value = modelo.com_data;
            lblTotalItens.Text = modelo.com_total.ToString("#0.00");
            //Itens compra
            CarregaItensCompra();
            alteraBotoes();
        }
        private void CarregaItensCompra()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLItensCompra bllItens = new BLLItensCompra(cx);
            DataTable tabela = bllItens.Localizar(codigo);
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                Double totalLocal = Convert.ToDouble(tabela.Rows[i]["QUANTIDADE"]) * Convert.ToDouble(tabela.Rows[i]["VALOR_UNITARIO"]);
                string icod = tabela.Rows[i]["CODIGO_PRODUTO"].ToString();
                string inome = tabela.Rows[i]["NOME_PRODUTO"].ToString();
                string iqtde = tabela.Rows[i]["QUANTIDADE"].ToString();
                Double ivalor = Convert.ToDouble(tabela.Rows[i]["VALOR_UNITARIO"]);
                String[] it = new String[] { icod, inome, iqtde, ivalor.ToString("#.00"), totalLocal.ToString("#.00") };
                dgvItensCompra.Rows.Add(it);
            }
        }
        private void CarregaComboBox()
        {
            carregaComboBox = false;
            //Fornecedor
            CarregaFornecedor();
            //Produto
            CarregaProduto();
            //Tipo Pagamento
            CarregaTipoPagamento();
            //Ativa sugestões
            cbxFornecedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxFornecedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxProduto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxProduto.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxTipoPagamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxTipoPagamento.AutoCompleteSource = AutoCompleteSource.ListItems;
            carregaComboBox = true;
        }
        private void CadastrarItensCompra(ModeloItensCompra mItens, ModeloCompra modeloCompra, BLLItensCompra bItens, ModeloParcelasCompra mParcelas, BLLParcelasCompra bParcelas)
        {
            DataRow linha;
            //Cadastrar os itens da compra
            for (int i = 0; i < dgvItensCompra.RowCount; i++)
            {
                linha = mItens.itenscompra.NewRow();
                linha["itc_qtde"] = Convert.ToInt32(dgvItensCompra.Rows[i].Cells[2].Value);
                linha["itc_valor"] = Convert.ToDouble(dgvItensCompra.Rows[i].Cells[3].Value);
                linha["com_cod"] = Convert.ToInt32(modeloCompra.com_cod);
                linha["pro_cod"] = Convert.ToInt32(dgvItensCompra.Rows[i].Cells[0].Value);
                mItens.itenscompra.Rows.Add(linha);
            }
            bItens.ItensCadastrarAtualizar(mItens);
            linha = null;
            //Cadastrar as parcelas da compra
            for (int i = 0; i < dgvParcelas.RowCount; i++)
            {
                linha = mParcelas.parcelascompra.NewRow();
                linha["pco_valor"] = Convert.ToDouble(dgvParcelas.Rows[i].Cells[1].Value);
                linha["pco_parcela"] = dgvParcelas.Rows[i].Cells[0].Value.ToString();
                linha["pco_datavecto"] = Convert.ToDateTime(dgvParcelas.Rows[i].Cells[2].Value);
                linha["com_cod"] = Convert.ToInt32(modeloCompra.com_cod);
                mParcelas.parcelascompra.Rows.Add(linha);
            }
            bParcelas.ParcelaCadastraAtualiza(mParcelas);
        }
        private void CarregaProduto()
        {
            carregaComboBox = false;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLProduto bll = new BLLProduto(cx);
            produto = bll.Localizar("");
            cbxProduto.DataSource = produto;
            cbxProduto.ValueMember = "CODIGO";
            cbxProduto.DisplayMember = "NOME";
            carregaComboBox = true;
        }
        private void CarregaFornecedor()
        {
            carregaComboBox = false;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLFornecedor fbll = new BLLFornecedor(cx);
            cbxFornecedor.DataSource = fbll.Localizar("");
            cbxFornecedor.ValueMember = "CODIGO";
            cbxFornecedor.DisplayMember = "NOME";
            carregaComboBox = true;
        }
        private void CarregaTipoPagamento()
        {
            carregaComboBox = false;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLTipoPagamento tbll = new BLLTipoPagamento(cx);
            cbxTipoPagamento.DataSource = tbll.Localizar("");
            cbxTipoPagamento.ValueMember = "CODIGO";
            cbxTipoPagamento.DisplayMember = "NOME";
            carregaComboBox = true;
        }
        private void ValorUnitario()
        {
            if (cbxProduto.SelectedValue != null)
            {
                DataRow[] linha = produto.Select("CODIGO = " + cbxProduto.SelectedValue);
                lblValorUnitario.Text = string.Format("{0:F}", linha[0]["VALOR_PAGO"]);
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
        private void Erro(string erro)
        {
            switch (erro)
            {
                case "data":
                    dtpDataInicialPagamento.Focus();
                    Mensagem("INSIRA A DATA DA COMPRA", Color.Red);
                    break;
                case "nfiscal":
                    txtNFiscal.Focus();
                    Mensagem("DIGITE A NOTA FISCAL", Color.Red);
                    break;
                case "total":
                    Mensagem("O VALOR TOTAL NÃO FOI CALCULADO", Color.Red);
                    break;
                case "nparcelas":
                    nudNumeroParcelas.Focus();
                    Mensagem("INSIRA AS PARCELAS", Color.Red);
                    break;
                case "status":
                    Mensagem("INSIRA O STATUS DA COMPRA", Color.Red);
                    break;
                case "for_cod":
                    cbxFornecedor.Focus();
                    Mensagem("SELECIONE O FORNECEDOR", Color.Red);
                    break;
                case "tpa_cod":
                    cbxTipoPagamento.Focus();
                    Mensagem("SELECIONE O TIPO DO PAGAMENTO", Color.Red);
                    break;
                case "parcelas":
                    Mensagem("NÃO FOI POSSÍVEL REALIZAR O PROCEDIMENTO POIS A COMPRA JÁ POSSUI PARCELAS PAGAS", Color.Red);
                    break;
                default:
                    Mensagem("NÃO FOI POSSÍVEL REALIZAR O PROCEDIMENTO", Color.Red);
                    break;
            }
        }
        private void Avancar()
        {
            btnAvancar.Enabled = (dgvItensCompra.RowCount > 0 && txtNFiscal.Text.Trim().Length > 0) ? true : false;
        }
        #endregion

        #region "Otimização"
        private void cbxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregaComboBox)
            {
                nudQuantidade.Value = 1;
                ValorUnitario();
            }
        }
        private void nudNumeroParcelas_ValueChanged(object sender, EventArgs e)
        {
            if (nudNumeroParcelas.Value == 1)
            {
                cbxTipoPagamento.Text = "À VISTA";
                dtpDataInicialPagamento.Focus();
            }
        }
        #endregion
    }
}

