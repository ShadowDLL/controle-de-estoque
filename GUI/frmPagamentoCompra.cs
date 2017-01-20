using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmPagamentoCompra : Form
    {
        private int pcocod = 0;
        private int comcod = 0;
        private DALConexao conexao;
        public frmPagamentoCompra()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            //Localizar a compra e preencher os campos
            frmConsultaCompra f = new frmConsultaCompra();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                this.comcod = f.codigo;
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
                BLLCompra bll = new BLLCompra(cx);
                ModeloCompra modelo = bll.CarregaModeloCompra(f.codigo);
                BLLFornecedor bllf = new BLLFornecedor(cx);
                ModeloFornecedor modelof = bllf.CarregaModeloFornecedor(modelo.for_cod);
                txtCodigoCompra.Text = modelo.com_cod.ToString();
                dtpDataPagamento.Value = modelo.com_data;
                txtValor.Text = modelo.com_total.ToString();
                txtNomeFornecedor.Text = modelof.for_nome;
                //Localizar os itens da compra
                BLLParcelasCompra bllp = new BLLParcelasCompra(cx);
                dgvParcelas.DataSource = bllp.Localizar(modelo.com_cod);
                dgvParcelas.Columns[4].Visible = false;
            }

        }
        private void btnPagarParcela_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLParcelasCompra bllp = new BLLParcelasCompra(cx);
            bllp.EfetuaPagamentoParcela(Convert.ToInt32(txtCodigoCompra.Text), this.pcocod, dtpDataPagamento.Value);
            btnPagarParcela.Enabled = false;
            dgvParcelas.DataSource = bllp.Localizar(this.comcod);
        }

        private void dgvParcelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnPagarParcela.Enabled = false;
            this.pcocod = 0;
            if (e.RowIndex != 0 && dgvParcelas.Rows[this.pcocod].Cells[2].Value == null)
            {
                this.pcocod = Convert.ToInt32(dgvParcelas.Rows[e.RowIndex].Cells[0].Value);
                btnPagarParcela.Enabled = true;
            }
        }




    }
}
