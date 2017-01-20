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
    public partial class frmConsultaSubCategoria : Form
    {
        public frmConsultaSubCategoria()
        {
            InitializeComponent();
        }
        private void frmConsultaSubCategoria_Load(object sender, EventArgs e)
        {
            Localizar();
            dgvDados.Columns[0].Width = 100;
            dgvDados.Columns[1].Width = 250;
            dgvDados.Columns[2].Width = 100;
            dgvDados.Columns[3].Width = 267;
            dgvDados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtValorSubCategoria.Focus();
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmCadastroSubCategoria f = new frmCadastroSubCategoria();
                f.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
                f.ShowDialog();
                f.Dispose();
            }
        }
        private void txtValorSubCategoria_KeyUp(object sender, KeyEventArgs e)
        {
            Localizar();
        }
        private void Localizar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexão);
            BLLSubCategoria bll = new BLLSubCategoria(cx);
            dgvDados.DataSource = bll.Localizar(txtValorSubCategoria.Text);
        }
    }
}
