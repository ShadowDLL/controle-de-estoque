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
using Ferramentas;

namespace GUI
{
    public partial class frmBackupBancoDeDados : Form
    {
        public frmBackupBancoDeDados()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Backup Files |*.bak";
            d.ShowDialog();
            if (d.FileName != "")
            {
                string conexao = @"Data Source=" + DadosDaConexao.servidor + ";Initial Catalog=master;User=" + DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha;
                SQLServerBackup.BackupDatabase(conexao, DadosDaConexao.banco, d.FileName);
                MessageBox.Show("Backup realizado com sucesso!!!");
            }
	        }
	catch (Exception erro )
	{
		
		throw new Exception(erro.Message);
	}
            
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try 
            {	  
		    OpenFileDialog d = new OpenFileDialog();
            d.Filter = "Restore Files |*.bak";
            d.ShowDialog();
            if (d.FileName != "")
            {
                string conexao = "Data Source=" + DadosDaConexao.servidor + ";Initial Catalog=master;User=" + DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha;
                SQLServerBackup.RestauraDatabase(conexao, DadosDaConexao.banco, d.FileName);
                MessageBox.Show("Restauração realizada com sucesso!!!");
            }
	        }
	catch (Exception erro )
	{
		
		throw new Exception(erro.Message);
	}
            
        }
        }
    }

