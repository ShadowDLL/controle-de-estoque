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

namespace GUI
{
    public partial class frmConsultaCliente : Form
    {
        public frmConsultaCliente()
        {
            InitializeComponent();
        }
        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {
            Localizar();
            txtValor.Focus();
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmCadastroCliente f = new frmCadastroCliente();
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
            BLLCliente bll = new BLLCliente(cx);
            dgvDados.DataSource = bll.LocalizarNome(txtValor.Text);
        }
    }
}
