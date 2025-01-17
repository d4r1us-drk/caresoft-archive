﻿using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;
namespace caresoft_core_client;

public partial class frmReporteConsultas : Form
{
    private readonly Client API;

    public frmReporteConsultas(string baseUrl)
    {
        InitializeComponent();
        API = new Client(baseUrl);
        LoadData();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }
    
    private async void LoadData()
    {
        try
        {
            var Consultas = await API.ApiConsultaGetAsync();

            if (Consultas != null)
            {
                FormHelper.InfoBox("No se encontraron consultas.");
            }
            else
            {
                dbgrdDatosConsultas.DataSource = Consultas;
            }
        } catch(Exception)
        {
            FormHelper.InfoBox("No se pudieron cargar los datos");
        }
       
    }
}
