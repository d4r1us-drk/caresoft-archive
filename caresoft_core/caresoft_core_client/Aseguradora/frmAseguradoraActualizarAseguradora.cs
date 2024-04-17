﻿using caresoft_core.CoreWebApi;
using Newtonsoft.Json;
using System.Text;

namespace caresoft_core_client
{
    public partial class frmAseguradoraActualizarAseguradora : Form
    {
        private readonly Client API;

        public frmAseguradoraActualizarAseguradora(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadAseguradoras();
        }

        private async void LoadAseguradoras()
        {
                try
                {

                    var aseguradoras = await API.ApiAseguradoraGetGetAsync();

                    dbgrdProductos.DataSource = aseguradoras;
                }
                catch (Exception)
                {
                    FormHelper.ErrorBox($"Error al cargar las aseguradoras");
                }
        }

     

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            if (dbgrdProductos.SelectedRows.Count == 0)
            {
                FormHelper.InfoBox("Seleccione una aseguradora.");
                return;
            }

            var selectedProduct = (Aseguradora)dbgrdProductos.SelectedRows[0].DataBoundItem;
            txtIdentificacion.Text = selectedProduct.IdAseguradora.ToString();
            txtNombre.Text = selectedProduct.Nombre;
            txtDireccion.Text = selectedProduct.Direccion;
            txtTelefono.Text = selectedProduct.Telefono;
            txtCorreo.Text = selectedProduct.Correo;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                FormHelper.InfoBox("Seleccione una aseguradora.");
                return;
            }

            var aseguradora = new Aseguradora
            {
                IdAseguradora = int.Parse(txtIdentificacion.Text),
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

                try
                {
                    await API.ApiAseguradoraUpdateAsync(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Direccion, aseguradora.Telefono, aseguradora.Correo, []);
                    FormHelper.InfoBox("Aseguradora actualizada correctamente.");
                    ClearFields();
                    LoadAseguradoras();
                }
                catch (Exception)
                {
                    FormHelper.ErrorBox($"No se pudo actualizar la aseguradora");
                }
        }

        private void ClearFields()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
    }
}
