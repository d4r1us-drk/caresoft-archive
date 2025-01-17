﻿using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caresoft_core_client.Servicios
{
    public partial class frmServiciosEliminarServicio : Form
    {
        private readonly Client API;

        public frmServiciosEliminarServicio(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadServicios();
        }
        private async void LoadServicios()
        {
            try
            {
                var servicios = await API.ApiServicioGetAsync();
                dataGridView1.DataSource = servicios;

            } catch (Exception ex)
            {
                FormHelper.ErrorBox("Error al cargar los servicios");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void DeleteServicios()
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.DataBoundItem is ServicioDto servicio)
                    {
                        await API.ApiServicioDeleteAsync(servicio.ServicioCodigo);
                    }
                }
                LoadServicios();
                FormHelper.InfoBox("Servicio eliminado correctamente");
            }
            catch (Exception)
            {
                FormHelper.ErrorBox("Error al eliminar el servicio");
            }
        }
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            FormHelper.ConfirmBox("¿Está seguro de que desea eliminar el servicio?", DeleteServicios, "Eliminar Servicios");
           
        }
    }
}
