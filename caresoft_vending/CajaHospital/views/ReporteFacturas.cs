﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class ReporteFacturas : UserControl
    {
        public List<FacturaDto> _facturas = new List<FacturaDto>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReporteFacturas()
        {
            InitializeComponent();
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            CargarFacturas(null, null, null);
            dgvFacturas.DataSource = _facturas;
            dgvFacturas.ReadOnly = true;


            if (dgvFacturas.Rows.Count > 0)
            {
                btnPagar.Enabled = true;
            }
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtDocCajero.Text = "";
            dtpInicial.Value = DateTime.Now;
            dtpFinal.Value = DateTime.Now;
            CargarFacturas(null, null, null);
            dgvFacturas.DataSource = _facturas;
            dgvFacturas.Refresh();

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string documento = String.IsNullOrWhiteSpace(txtDocCajero.Text) ? null : txtDocCajero.Text;
            DateTime fechaInicio = dtpInicial.Value;
            DateTime fechaFinal = dtpFinal.Value;
            CargarFacturas(documento, fechaInicio, fechaFinal);
            dgvFacturas.DataSource = _facturas;
            dgvFacturas.Refresh();
        }

        private void CargarFacturas( string documentoCajero, DateTime? fechaInicio, DateTime? fechaFin)
        {
            FacturaDto facturaDto = null;
            dgvFacturas.DataSource = null;
            _facturas.Clear();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("spFacturaListar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("p_documentoCajero", documentoCajero);
            cmd.Parameters.AddWithValue("p_fechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("p_fechaFin", fechaFin);
            log.Info("Consultando facturas...");
            MySqlDataReader reader = cmd.ExecuteReader();
            log.Info("Facturas consultadas");

            while (reader.Read())
            {
                facturaDto = new FacturaDto();

                facturaDto.FacturaCodigo = reader.GetString("facturaCodigo");
                facturaDto.IdCuenta = reader.GetUInt32("idCuenta");
                facturaDto.IdSucursal = reader.GetUInt32("idSucursal");
                facturaDto.DocumentoCajero = reader.GetString("documentoCajero");
                facturaDto.MontoSubtotal = reader.GetDecimal("montoSubtotal");
                facturaDto.MontoTotal = reader.GetDecimal("montoTotal");
                facturaDto.Fecha = reader.GetDateTime("fecha");
                facturaDto.Estado = reader.GetChar("estado");

                _facturas.Add(facturaDto);
            }

            conn.Close();
        }

        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccione solo una factura para pagar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ( dgvFacturas.SelectedRows.Count < 1)
            {
                MessageBox.Show("Seleccione una factura para pagar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                if (Convert.ToChar(dgvFacturas.SelectedRows[0].Cells[7].Value) == 'P')
                {
                    frmDetallesFactura frmDetalles = new frmDetallesFactura(dgvFacturas.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToDecimal(dgvFacturas.SelectedRows[0].Cells[5].Value), Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[1].Value));
                    frmDetalles.ShowDialog();
                    if (frmDetalles.DialogResult == DialogResult.OK)
                    {
                        MessageBox.Show($"Factura codigo: {dgvFacturas.SelectedRows[0].Cells[0].Value.ToString()} fue pagada con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else
                {
                    MessageBox.Show("Esta factura ya fue pagada");
                }
            }
        }

        public List<FacturaProductoDto> cargarProductos(string codigoFactura)
        {
            List<FacturaProductoDto> productos = new List<FacturaProductoDto>();
            FacturaProductoDto producto = new FacturaProductoDto();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("spFacturaListarProductos", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p_facturaCodigo", codigoFactura);

            log.Info($"Listando productos de la factura #{codigoFactura}...");
            MySqlDataReader reader = cmd.ExecuteReader();
            log.Info($"Productos de la factura #{codigoFactura} listados");

            while (reader.Read())
            {
                producto.FacturaCodigo = codigoFactura;
                producto.IdProducto = reader.GetUInt32("idProducto");
                producto.Resultados = reader.GetString("resultados");
                producto.Costo = reader.GetDecimal("costo");

                productos.Add(producto);
            }

            return productos;
        }
        public List<FacturaServicioDto> cargarServicios(string codigoFactura)
        {
            List<FacturaServicioDto> servicios = new List<FacturaServicioDto>();
            FacturaServicioDto servicio = new FacturaServicioDto();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("spFacturaListarServicios", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p_facturaCodigo", codigoFactura);

            log.Info($"Listando servicios de la factura #{codigoFactura}...");
            MySqlDataReader reader = cmd.ExecuteReader();
            log.Info($"Servicios de la factura #{codigoFactura} listados");

            while (reader.Read())
            {
                servicio.FacturaCodigo = codigoFactura;
                servicio.ServicioCodigo = reader.GetString("servicioCodigo");
                servicio.Resultados = reader.GetString("resultados");
                servicio.Costo = reader.GetDecimal("costo");

                servicios.Add(servicio);
            }

            return servicios;
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            List<FacturaDto> factura = new List<FacturaDto> ();
            List<FacturaProductoDto> productos = new List<FacturaProductoDto> ();
            List<FacturaServicioDto> servicios = new List<FacturaServicioDto> ();

            if (dgvFacturas.SelectedRows.Count > 0)
            {
                factura.Add(_facturas.Find(x => x.FacturaCodigo == dgvFacturas.SelectedRows[0].Cells[0].Value.ToString()));

                productos = cargarProductos(factura[0].FacturaCodigo);
                servicios = cargarServicios(factura[0].FacturaCodigo);

                ReciboFacturas reciboView = new ReciboFacturas(factura, servicios, productos);
                reciboView.ShowDialog();
            }

        }
    }
}
