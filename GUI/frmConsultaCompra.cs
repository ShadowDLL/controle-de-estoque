using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Modelo;
using BLL;

namespace GUI
{
    public partial class frmConsultaCompra : Form
    {
        #region "Variáveis"
        public int codigo { get; set; }
        #endregion

        #region "Eventos"
        public frmConsultaCompra()
        {
            InitializeComponent();
        }
        private void frmConsultaCompra_Load(object sender, EventArgs e)
        {
            CarregaFornecedor();
        }
        private void cbxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarCompras();
        }
        private void rbGeral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGeral.Checked)
            {
                ConsultarCompras();
            }
        }
        private void rbFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFornecedor.Checked)
            {
                ConsultarCompras();
            }
        }
        private void rbData_CheckedChanged(object sender, EventArgs e)
        {
            if (rbData.Checked)
            {
                ConsultarCompras();
            }
        }
        private void rbParcelas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbParcelas.Checked)
            {
                ConsultarCompras();
            }
        }
        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmMovimentacaoCompra f = new frmMovimentacaoCompra();
                f.codigo = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells["CODIGO"].Value);
                Close();
                f.ShowDialog();
                f.Dispose();
            }
        }
        private void btnAdicionaFornecedor_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedor f = new frmCadastroFornecedor();
            f.ShowDialog();
            f.Dispose();
            CarregaFornecedor();
        }
        private void tbcDados_MouseClick(object sender, MouseEventArgs e)
        {
            btnParcela.Visible = false;
            switch (tbcDados.SelectedIndex)
            {
                case 0:
                    ConsultarCompras();
                    break;
                case 1:
                    ItensCompra();
                    break;
                case 2:
                    ParcelasCompra();
                    SelecionarParcelaNaoPaga();
                    if (dgvParcelas.RowCount > 0)
                    {
                        btnParcela.Visible = true;
                        btnParcela.Text = (dgvParcelas.CurrentRow.Cells[2].Value.ToString() == "") ? "Pagar Parcela" : "Cancelar Pagamento";
                    }
                    break;
            }
        }
        private void btnParcela_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCompra bll = new BLLCompra(cx);
            int codigocompra = Convert.ToInt32(dgvCompras.CurrentRow.Cells["CODIGO"].Value);
            int parcelacompra = Convert.ToInt32(dgvParcelas.CurrentRow.Cells[0].Value);
            try
            {
                if (btnParcela.Text == "Pagar Parcela")
                {
                    bll.ParcelasCompraPagar(codigocompra, parcelacompra);
                    Mensagem("PAGAMENTO DA PARCELA REALIZADO COM SUCESSO. ", Color.Blue);
                }
                else
                {
                    DialogResult result = MessageBox.Show("DESEJA REALMENTE CANCELAR O PAGAMENTO SELECIONADO? ", "AVISO", MessageBoxButtons.YesNo);
                    if (result.ToString() == "Yes")
                    {
                        bll.ParcelasCompraCancelar(codigocompra, parcelacompra);
                        Mensagem("PAGAMENTO DA PARCELA CANCELADO COM SUCESSO. ", Color.Blue);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception erro)
            {
                Erro("ERRO AO REALIZAR A OPERAÇÃO " + erro.Message); ;
            }
            bll.AtualizaStatusCompra(codigocompra);
            ParcelasCompra();
            SelecionarParcelaNaoPaga();
            btnParcela.Text = (dgvParcelas.CurrentRow.Cells["DATA_PAGAMENTO"].Value.ToString() == "") ? "Pagar Parcela" : "Cancelar Pagamento";
        }
        private void dgvParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParcelas.RowCount > 0)
            {
                btnParcela.Text = (dgvParcelas.CurrentRow.Cells[2].Value.ToString() == "") ? "Pagar Parcela" : "Cancelar Pagamento";
            }
        }
        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            dtpDataInicial.Value = (dtpDataInicial.Value > DateTime.Now) ? DateTime.Now : dtpDataInicial.Value;
            dtpDataInicial.Value = (dtpDataInicial.Value > dtpDataFinal.Value) ? dtpDataFinal.Value : dtpDataInicial.Value;
            ConsultarCompras();
        }
        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            dtpDataFinal.Value = (dtpDataFinal.Value > DateTime.Now) ? DateTime.Now : dtpDataFinal.Value;
            dtpDataInicial.Value = (dtpDataInicial.Value > dtpDataFinal.Value) ? dtpDataFinal.Value : dtpDataInicial.Value;
            ConsultarCompras();
        }
        #endregion

        #region "Funções"
        private void ConsultarCompras()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLCompra bll = new BLLCompra(cx);
            Opcoes();
            tbcDados.SelectTab("tabCompra");
            if (rbGeral.Checked)
            {
                dgvCompras.DataSource = bll.Localizar();
            }
            else if (rbFornecedor.Checked)
            {
                dgvCompras.DataSource = bll.Localizar(Convert.ToInt32(cbxFornecedor.SelectedValue));
            }
            else if (rbData.Checked)
            {
                dgvCompras.DataSource = bll.Localizar(dtpDataInicial.Value, dtpDataFinal.Value);
            }
            else
            {
                dgvCompras.DataSource = bll.LocalizarParcelasEmAberto();
            }
            FormatarValoresCores(1);
        }
        private void status()
        {
            if (dgvCompras.RowCount > 0)
            {
                for (int j = 0; j < dgvCompras.RowCount; j++)
                {
                    switch (dgvCompras.Rows[j].Cells[1].Value.ToString())
                    {
                        case "ATIVA":
                            dgvCompras.Rows[j].Cells[0].Value = System.Drawing.Image.FromFile(@"status\verde.png");
                            dgvCompras.Rows[j].Cells[0].ToolTipText = "COMPRA ATIVA";
                            break;
                        case "CANCELADA":
                            dgvCompras.Rows[j].Cells[0].Value = System.Drawing.Image.FromFile(@"status\vermelho.png");
                            dgvCompras.Rows[j].Cells[0].ToolTipText = "COMPRA CANCELADA";
                            break;
                        case "FINALIZADA":
                            dgvCompras.Rows[j].Cells[0].Value = System.Drawing.Image.FromFile(@"status\azul.png");
                            dgvCompras.Rows[j].Cells[0].ToolTipText = "COMPRA FINALIZADA";
                            break;
                        default:
                            dgvCompras.Rows[j].Cells[0].Value = System.Drawing.Image.FromFile(@"status\amarelo.png");
                            dgvCompras.Rows[j].Cells[0].ToolTipText = "COMPRA COM PARCELAS EM ATRAZO, VERIFICAR NA GUIA PARCELAS";
                            break;
                    }
                }
                switch (dgvCompras.CurrentRow.Cells[1].Value.ToString())
                {
                    case "ATIVA":
                        dgvCompras.CurrentRow.Cells[0].Value = System.Drawing.Image.FromFile(@"status\verde azul.png");
                        break;
                    case "CANCELADA":
                        dgvCompras.CurrentRow.Cells[0].Value = System.Drawing.Image.FromFile(@"status\vermelho azul.png");
                        break;
                    case "FINALIZADA":
                        dgvCompras.CurrentRow.Cells[0].Value = System.Drawing.Image.FromFile(@"status\azul azul.png");
                        break;
                    default:
                        dgvCompras.CurrentRow.Cells[0].Value = System.Drawing.Image.FromFile(@"status\amarelo azul.png");
                        break;
                }
            }
        }
        private void FormatarValoresCores(int tabela)
        {
            switch (tabela)
            {
                case 1://Tabela Compras
                    if (dgvCompras.RowCount >= 0)
                    {
                        for (int i = 0; i < dgvCompras.RowCount; i++)
                        {
                            double valor = Convert.ToDouble(dgvCompras.Rows[i].Cells["TOTAL"].Value);
                            string val = valor.ToString("#.00");
                            dgvCompras.Rows[i].Cells["TOTAL"].Value = val;
                        }
                        status();
                        EsconderColunas();
                    }
                    break;
                case 2://Tabela Itens
                    if (dgvItens.RowCount >= 0)
                    {
                        for (int i = 0; i < dgvItens.RowCount; i++)
                        {
                            double valor = Convert.ToDouble(dgvItens.Rows[i].Cells[3].Value);
                            string val = valor.ToString("#.00");
                            dgvItens.Rows[i].Cells["VALOR_UNITARIO"].Value = val;
                        }
                    }
                    break;
                case 3://Tabela Parcelas
                    if (dgvParcelas.RowCount >= 0)
                    {
                        for (int i = 0; i < dgvParcelas.RowCount; i++)
                        {
                            double valor = Convert.ToDouble(dgvParcelas.Rows[i].Cells["VALOR"].Value);
                            string val = valor.ToString("#.00");
                            dgvParcelas.Rows[i].Cells["VALOR"].Value = val;
                        }
                    }
                    break;
            }
        }
        private void ItensCompra()
        {
            if (dgvCompras.RowCount > 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLItensCompra ibll = new BLLItensCompra(cx);
                dgvItens.DataSource = ibll.Localizar(Convert.ToInt32(dgvCompras.CurrentRow.Cells["CODIGO"].Value));
                FormatarValoresCores(2);
            }
        }
        private void ParcelasCompra()
        {
            if (dgvCompras.RowCount > 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLParcelasCompra pbll = new BLLParcelasCompra(cx);
                dgvParcelas.DataSource = pbll.Localizar(Convert.ToInt32(dgvCompras.CurrentRow.Cells["CODIGO"].Value));
                FormatarValoresCores(3);
            }
        }
        private void Opcoes()
        {
            //Ocultar paineis 
            pnFornecedor.Visible = false;
            pnData.Visible = false;
            if (rbData.Checked)
            {
                pnData.Visible = true;
                this.pnData.Location = new Point(12, 88);
            }
            else if (rbFornecedor.Checked)
            {
                pnFornecedor.Visible = true;
            }
        }
        private void CarregaFornecedor()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLFornecedor fbll = new BLLFornecedor(cx);
            cbxFornecedor.DataSource = fbll.Localizar("");
            cbxFornecedor.ValueMember = "CODIGO";
            cbxFornecedor.DisplayMember = "NOME";
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
                default:
                    Erro("ERRO AO INSERIR OU ALTERAR O CLIENTE " + erro);
                    break;
            }
        }
        private void EsconderColunas()
        {
            if (dgvCompras.RowCount > 0)
            {
                dgvCompras.Columns[1].Visible = false;
            }
            if (dgvParcelas.RowCount > 0)
            {
                dgvParcelas.Columns[0].Visible = false;
            }
        }
        private void SelecionarParcelaNaoPaga()
        {
            if (dgvParcelas.RowCount > 0)
            {
                if (dgvParcelas.Rows[0].Cells["DATA_PAGAMENTO"].Value.ToString() != "")
                {
                    for (int i = 1; i <= dgvParcelas.RowCount; i++)
                    {
                        if (dgvParcelas.Rows[i].Cells["DATA_PAGAMENTO"].Value.ToString() == "")
                        {
                            dgvParcelas.Rows[i].Selected = true;
                            return;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
