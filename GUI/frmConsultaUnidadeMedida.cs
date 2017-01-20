using BLL;
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

namespace GUI
{
    public partial class frmConsultaUnidadeMedida : Form
    {
        public frmConsultaUnidadeMedida()
        {
            InitializeComponent();
        }
        private void frmConsultaUnidadeMedida_Load(object sender, EventArgs e)
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
                frmCadastroUnidadeMedida f = new frmCadastroUnidadeMedida();
                f.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
                f.ShowDialog();
                f.Dispose();
            }
        }
        private void Localizar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLUnidadeMedida bll = new BLLUnidadeMedida(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }
        private void txtValor_KeyUp(object sender, KeyEventArgs e)
        {
            Localizar();
        }
    }
}
