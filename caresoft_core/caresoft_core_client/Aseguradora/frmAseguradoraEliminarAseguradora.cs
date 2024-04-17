﻿
using caresoft_core.CoreWebApi;

namespace caresoft_core_client
{
    public partial class frmAseguradoraEliminarAseguradora : Form
    {
        private readonly Client API;
        public frmAseguradoraEliminarAseguradora(string baseURL)
        {
            API = new(baseURL);
            InitializeComponent();
            LoadProductos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void LoadProductos()
        {
            try
            {

                var proveedores = await API.ApiProveedorGetGetAsync();

                dataGridView1.DataSource = proveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas seguro que deseas eliminar el proveedor?", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        var producto = (ProveedorDto)row.DataBoundItem;
                        if (producto != null)
                            await API.ApiProveedorDeleteAsync(producto.RncProveedor);
                    }
                    LoadProductos();
                } catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}