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
    public partial class frmConsultaUsuário : Form
    {
        frmPrincipal principal;
        public frmConsultaUsuário()
        {
            InitializeComponent();
        }
        public frmConsultaUsuário(frmPrincipal f)
        {
            InitializeComponent();
            principal = f;
        }
        private void frmConsultaUsuário_Load(object sender, EventArgs e)
        {
            Localizar();
            txtValor.Focus();
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //frmCadastroUsuario f = new frmCadastroUsuario(principal);
                frmCadastroUsuario f = new frmCadastroUsuario();
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
            BLLUsuario bll = new BLLUsuario(cx);
            dgvDados.DataSource = bll.LocalizarNome(txtValor.Text);
        }    
    }
}
