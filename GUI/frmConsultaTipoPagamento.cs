using DAL;
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

namespace GUI
{
    public partial class frmConsultaTipoPagamento : Form
    {
        public frmConsultaTipoPagamento()
        {
            InitializeComponent();
        }
        private void frmConsultaTipoPagamento_Load(object sender, EventArgs e)
        {
            Localizar();
            dgvDados.Columns[0].Width = 100;
            dgvDados.Columns[1].Width = 617;
            dgvDados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtValor.Focus();
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmCadastroTipoPagamento f = new frmCadastroTipoPagamento();
                f.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
                f.ShowDialog();
                f.Dispose();
            }
        }  
        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            Localizar();
        }
        private void Localizar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLTipoPagamento bll = new BLLTipoPagamento(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }
    }
}
