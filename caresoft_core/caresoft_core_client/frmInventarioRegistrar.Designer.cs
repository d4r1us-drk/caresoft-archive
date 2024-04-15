﻿namespace caresoft_core_client
{
    partial class frmInventarioRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioRegistrar));
            lblProveedorProducto = new Label();
            lblLoteProducto = new Label();
            txtLoteProducto = new TextBox();
            lblCostoProducto = new Label();
            txtCostoProducto = new TextBox();
            lblDescripcionProducto = new Label();
            txtDescripcionProducto = new TextBox();
            lblNombreProducto = new Label();
            txtNombreProducto = new TextBox();
            lblTitulo = new Label();
            btnRegistrar = new Button();
            button1 = new Button();
            pnlInputDatos = new Panel();
            chklbProveedores = new CheckedListBox();
            pnlTitulo = new Panel();
            pnlBotones = new Panel();
            pnlInputDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblProveedorProducto
            // 
            lblProveedorProducto.AutoSize = true;
            lblProveedorProducto.Location = new Point(19, 303);
            lblProveedorProducto.Name = "lblProveedorProducto";
            lblProveedorProducto.Size = new Size(72, 15);
            lblProveedorProducto.TabIndex = 25;
            lblProveedorProducto.Text = "Proveedores";
            // 
            // lblLoteProducto
            // 
            lblLoteProducto.AutoSize = true;
            lblLoteProducto.Location = new Point(19, 260);
            lblLoteProducto.Name = "lblLoteProducto";
            lblLoteProducto.Size = new Size(89, 15);
            lblLoteProducto.TabIndex = 23;
            lblLoteProducto.Text = "Lote Disponible";
            // 
            // txtLoteProducto
            // 
            txtLoteProducto.Location = new Point(126, 257);
            txtLoteProducto.Name = "txtLoteProducto";
            txtLoteProducto.Size = new Size(148, 23);
            txtLoteProducto.TabIndex = 22;
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(19, 217);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(38, 15);
            lblCostoProducto.TabIndex = 21;
            lblCostoProducto.Text = "Costo";
            // 
            // txtCostoProducto
            // 
            txtCostoProducto.Location = new Point(126, 214);
            txtCostoProducto.Name = "txtCostoProducto";
            txtCostoProducto.Size = new Size(148, 23);
            txtCostoProducto.TabIndex = 20;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(19, 120);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(69, 15);
            lblDescripcionProducto.TabIndex = 19;
            lblDescripcionProducto.Text = "Descripción";
            // 
            // txtDescripcionProducto
            // 
            txtDescripcionProducto.Location = new Point(126, 117);
            txtDescripcionProducto.Multiline = true;
            txtDescripcionProducto.Name = "txtDescripcionProducto";
            txtDescripcionProducto.Size = new Size(148, 79);
            txtDescripcionProducto.TabIndex = 18;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(19, 81);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 17;
            lblNombreProducto.Text = "Nombre";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(126, 78);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(148, 23);
            txtNombreProducto.TabIndex = 16;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(64, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(161, 25);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir Producto";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Dock = DockStyle.Right;
            btnRegistrar.Location = new Point(216, 0);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 32);
            btnRegistrar.TabIndex = 27;
            btnRegistrar.Text = "Añadir";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 32);
            button1.TabIndex = 28;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pnlInputDatos
            // 
            pnlInputDatos.Controls.Add(chklbProveedores);
            pnlInputDatos.Controls.Add(txtNombreProducto);
            pnlInputDatos.Controls.Add(lblNombreProducto);
            pnlInputDatos.Controls.Add(txtDescripcionProducto);
            pnlInputDatos.Controls.Add(lblDescripcionProducto);
            pnlInputDatos.Controls.Add(lblProveedorProducto);
            pnlInputDatos.Controls.Add(txtCostoProducto);
            pnlInputDatos.Controls.Add(lblCostoProducto);
            pnlInputDatos.Controls.Add(lblLoteProducto);
            pnlInputDatos.Controls.Add(txtLoteProducto);
            pnlInputDatos.Dock = DockStyle.Fill;
            pnlInputDatos.Location = new Point(0, 0);
            pnlInputDatos.Name = "pnlInputDatos";
            pnlInputDatos.Size = new Size(291, 466);
            pnlInputDatos.TabIndex = 29;
            // 
            // chklbProveedores
            // 
            chklbProveedores.FormattingEnabled = true;
            chklbProveedores.Location = new Point(126, 303);
            chklbProveedores.Name = "chklbProveedores";
            chklbProveedores.Size = new Size(148, 112);
            chklbProveedores.TabIndex = 26;
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(291, 57);
            pnlTitulo.TabIndex = 30;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnRegistrar);
            pnlBotones.Controls.Add(button1);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 434);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(291, 32);
            pnlBotones.TabIndex = 31;
            // 
            // frmInventarioRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 466);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            Controls.Add(pnlInputDatos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInventarioRegistrar";
            Text = "Añadir producto";
            pnlInputDatos.ResumeLayout(false);
            pnlInputDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblProveedorProducto;
        private Label lblLoteProducto;
        private TextBox txtLoteProducto;
        private Label lblCostoProducto;
        private TextBox txtCostoProducto;
        private Label lblDescripcionProducto;
        private TextBox txtDescripcionProducto;
        private Label lblNombreProducto;
        private TextBox txtNombreProducto;
        private Label lblTitulo;
        private Button btnRegistrar;
        private Button button1;
        private Panel pnlInputDatos;
        private Panel pnlTitulo;
        private Panel pnlBotones;
        private CheckedListBox chklbProveedores;
    }
}