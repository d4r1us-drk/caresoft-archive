﻿using caresoft_core.CoreWebApi;

namespace caresoft_core_client
{
    public partial class frmAseguradoraRegistrarAseguradora : Form
    {

        private readonly Client API;

        public frmAseguradoraRegistrarAseguradora(string baseURL)
        {
            API = new(baseURL);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Get input values
            int rnc;
            try
            {
                rnc = Convert.ToInt32(txtRncProveedor.Text.Trim());
            } catch (Exception ex)
            {
                MessageBox.Show("El RNC debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nombre = txtNombreProveedor.Text.Trim();
            string direccion = txtDireccionProveedor.Text.Trim();
            string telefono = txtTelefonoProveedor.Text;
            string correo = txtCorreoProveedor.Text;

            // Get selected providers
            var newProvider = new ProveedorDto
            {
                RncProveedor = rnc,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Correo = correo
            };
            try
            {

                await API.ApiProveedorAddAsync(rncProveedor: newProvider.RncProveedor, nombre: newProvider.Nombre, direccion: newProvider.Direccion, telefono: newProvider.Telefono, correo: newProvider.Correo);
                MessageBox.Show("Proveedor registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show($"El proveedor ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      
    }
}