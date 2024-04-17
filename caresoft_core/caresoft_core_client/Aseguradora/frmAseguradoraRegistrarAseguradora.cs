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
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;

            try
            {

                await API.ApiAseguradoraAddAsync(null, nombre, direccion, telefono, correo, []);
                FormHelper.InfoBox("Aseguradora registrada correctamente.");
            } catch (Exception)
            {
                FormHelper.ErrorBox("No se pudo añadir la aseguradora");
            }

        }

      
    }
}
