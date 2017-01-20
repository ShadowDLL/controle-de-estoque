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
    public partial class frmConsultaProduto : Form
    {
        public frmConsultaProduto()
        {
            InitializeComponent();
        }
        private void frmConsultaProduto_Load(object sender, EventArgs e)
        {
            Localizar();
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].Width = 100;
            dgvDados.Columns[2].Width = 200;
            dgvDados.Columns[3].Width = 50;
            dgvDados.Columns[4].Width = 50;
            dgvDados.Columns[5].Width = 50;
            dgvDados.Columns[6].Width = 50;
            dgvDados.Columns[7].Width = 50;
            dgvDados.Columns[8].Width = 50;
            dgvDados.Columns[9].Width = 50;
            dgvDados.Columns[10].Width = 50;
            dgvDados.Columns[11].Width = 50;
            dgvDados.Columns[12].Width = 50;
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmCadastroProduto f = new frmCadastroProduto();
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
            BLLProduto bll = new BLLProduto(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }
    }
}
