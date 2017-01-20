﻿namespace GUI
{
    partial class frmConsultaUsuário
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.tltMensagem = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 63);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(760, 488);
            this.dgvDados.TabIndex = 11;
            this.tltMensagem.SetToolTip(this.dgvDados, "Clique 2 vezes para editar o registro");
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuário";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 26);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(760, 20);
            this.txtValor.TabIndex = 9;
            this.tltMensagem.SetToolTip(this.txtValor, "Digite o nome do usuário");
            this.txtValor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyUp);
            // 
            // frmConsultaUsuário
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Name = "frmConsultaUsuário";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Usuário";
            this.Load += new System.EventHandler(this.frmConsultaUsuário_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ToolTip tltMensagem;
    }
}