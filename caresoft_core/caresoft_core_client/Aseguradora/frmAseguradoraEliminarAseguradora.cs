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
            LoadAseguradoras();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void LoadAseguradoras()
        {
            try
            {

                var aseguradoras = await API.ApiAseguradoraGetGetAsync();

                dataGridView1.DataSource = aseguradoras;
            }
            catch (Exception ex)
            {
                FormHelper.ErrorBox($"No se pudieron cargar las aseguradoras");
            }
        }

        private async void DeleteAseguradoras()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var aseguradora = (Aseguradora)row.DataBoundItem;
                    if (aseguradora != null)
                        await API.ApiAseguradoraDeleteAsync(aseguradora.IdAseguradora);
                }
                LoadAseguradoras();
                FormHelper.InfoBox("Aseguradora eliminada correctamente");
            }
            catch (Exception ex)
            {

                FormHelper.ErrorBox(ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            FormHelper.ConfirmBox("Estas seguro que deseas eliminar la aseguradora?", DeleteAseguradoras,"Eliminar Aseguradora");
        }
    }
}
