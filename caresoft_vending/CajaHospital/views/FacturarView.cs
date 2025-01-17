﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static CajaHospital.Main;
using static CajaHospital.views.RegistrarPaciente;
using static Mysqlx.Crud.Order.Types;

namespace CajaHospital.views
{
    public partial class FacturarView : UserControl
    {
        readonly char _tipoFactura;
        readonly string _documentoCajero;
        private Dictionary<string, string> servicios = new Dictionary<string, string>();
        private Dictionary<string, int> servicios_costos = new Dictionary<string, int>();
        private Dictionary<string, int> productos = new Dictionary<string, int>();
        private Dictionary<int, int> productos_costos = new Dictionary<int, int>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FacturarView( char tipoFactura, string documentoCajero = "" )
        {
            InitializeComponent();
            _tipoFactura = tipoFactura;
            _documentoCajero = documentoCajero;
        }

        private void FacturarView_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnRemover.Enabled = false;
            btnCrearFactura.Enabled = false;

            switch (_tipoFactura)
            {
                case 'E':
                    lblTitulo.Text = "Generar factura para paciente";

                    try
                    {
                        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("spServicioListar", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        MySqlDataReader reader = cmd.ExecuteReader();
                        log.Info("Consultando servicios...");

                        while (reader.Read())
                        {
                            servicios.Add(reader.GetString("nombre"), reader.GetString("servicioCodigo"));
                            servicios_costos.Add(reader.GetString("servicioCodigo"), reader.GetInt32("costo"));
                        }
                        foreach (var item in servicios )
                        {
                            lsbDisponibles.Items.Add(item.Key);
                        }

                        conn.Close();
                        
                        conn.Open();

                        cmd = new MySqlCommand("spProductoListar", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@p_costo", null);

                        reader = cmd.ExecuteReader();
                        log.Info("Consultando productos...");

                        while (reader.Read())
                        {
                            productos.Add(reader.GetString("nombre"), reader.GetInt32("idProducto"));
                            productos_costos.Add(reader.GetInt32("idProducto"), reader.GetInt32("costo"));
                        }
                        foreach (var item in productos)
                        {
                            lsbDisponibles.Items.Add(item.Key);
                        }

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algo salió mal", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(ex.Message, ex.Source);
                        log.Error("Algo salió mal", ex);
                    };

                    break;
                default:
                    break;
            }

        }


        //Manejador del evento de la creacion de la cuenta de un nuevo paciente
        private void CuentaLista(object sender, EventArgs e )
        {
            if ( e is CuentaListaArgs eventArgs)
            {
                txtDoc.Text = eventArgs.Documento;
                cboTipoDoc.SelectedIndex = eventArgs.TipoDoc == 'I' ? 1 : 2;
                txtDoc.ReadOnly = true;
                cboTipoDoc.Enabled = false;
            }
        }

        private string CalcularSubtotal()
        {
            log.Info("Calculando subtotal...");
            string seleccionado;
            int subtotal = 0;

            foreach (var item in lsbSeleccionados.Items)
            {
                seleccionado = item.ToString();

                if (servicios.ContainsKey(seleccionado))
                {
                    subtotal += servicios_costos[servicios[seleccionado]];
                }
                else
                {
                    subtotal += productos_costos[productos[seleccionado]];
                }
            }

            return subtotal.ToString();
        }

        private int RecuperarIdCuenta()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("spListarCuenta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_documentoUsuario", txtDoc.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                log.Info($"Recuperando cuenta con el documento {txtDoc.Text}...");
                reader.Read();
                int cuenta = reader.GetInt32("idCuenta");
                conn.Close();

                return cuenta;
            }
            catch (Exception err)
            {
                log.Error("No se pudo recuperar la cuenta", err);
                return -1;
                throw;
            }
        }

        private void lsbDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;

            string seleccionado = lsbDisponibles.SelectedItem.ToString();

            if (servicios.ContainsKey(seleccionado))
            {
                txtPrecio.Text = servicios_costos[servicios[seleccionado]].ToString();
            } else
            {
                txtPrecio.Text = productos_costos[productos[seleccionado]].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lsbSeleccionados.Items.Add(lsbDisponibles.SelectedItem.ToString());
            txtSubtotal.Text = CalcularSubtotal();
            btnCrearFactura.Enabled = true;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            lsbSeleccionados.Items.RemoveAt(lsbSeleccionados.SelectedIndex);
            txtSubtotal.Text = CalcularSubtotal();
        }

        private void lsbSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemover.Enabled = true;
        }

        private void btnCrearFactura_Click(object sender, EventArgs e)
        {
            int idCuenta = RecuperarIdCuenta();
            string facturaCodigo = Guid.NewGuid().ToString().Substring(2, 30);

            if (idCuenta == -1 )
            {
                MessageBox.Show("No se ha encontrado la cuenta especificada", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Warn($"No se ha encontrado la cuenta especificada!");
                return;
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand("spFacturaCrear", conn, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_facturaCodigo", facturaCodigo);
                cmd.Parameters.AddWithValue("@p_idCuenta", idCuenta);
                cmd.Parameters.AddWithValue("@p_idSucursal", ConfigurationManager.AppSettings["noSucursal"]);
                cmd.Parameters.AddWithValue("@p_documentoCajero", _documentoCajero);
                cmd.Parameters.AddWithValue("@p_monto", Convert.ToDecimal(txtSubtotal.Text));

                cmd.ExecuteNonQuery();
                log.Info($"Creando factura #{facturaCodigo}...");
                transaction.Commit();
                log.Info($"Factura creada correctamente con ID: {facturaCodigo}");
                conn.Close();

                Dictionary<string, int> cantidades = new Dictionary<string, int>();
                foreach (var item in lsbSeleccionados.Items)
                {
                    string seleccionado = item.ToString();

                    if (cantidades.ContainsKey(seleccionado) )
                    {
                        cantidades[seleccionado]++;
                    } else
                    {
                        cantidades.Add(seleccionado, 1);
                    }
                }
                foreach (var item in cantidades.Keys)
                {
                    string seleccionado = item.ToString();
                    conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    try
                    {
                        if (servicios.ContainsKey(seleccionado))
                        {
                            string codigo = servicios[seleccionado];
                            decimal costo = Convert.ToDecimal(servicios_costos[codigo]) + 0.00M;

                            cmd = new MySqlCommand("spFacturaRelacionarServicio", conn);
                            cmd.CommandType=CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@p_facturaCodigo", facturaCodigo);
                            cmd.Parameters.AddWithValue("@p_servicioCodigo", codigo);
                            cmd.Parameters.AddWithValue("@p_resultados", cantidades[seleccionado]);
                            cmd.Parameters.AddWithValue("@p_costo", costo);
                            log.Info($"Relacionando servicio {codigo} con factura {facturaCodigo}...");
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            int codigo = productos[seleccionado];
                            decimal costo = Convert.ToDecimal(productos_costos[codigo]) + 0.00M;

                            cmd = new MySqlCommand("spFacturaRelacionarProducto", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@p_facturaCodigo", facturaCodigo);
                            cmd.Parameters.AddWithValue("@p_idProducto", codigo);
                            cmd.Parameters.AddWithValue("@p_resultados", cantidades[seleccionado]);
                            cmd.Parameters.AddWithValue("@p_costo", costo);
                            log.Info($"Relacionando producto {codigo} con factura {facturaCodigo}...");
                            cmd.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        log.Error($"Algo salio mal, la factura no se registro", ex);
                        MessageBox.Show("Algo salio mal, la factura no se registro", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        transaction.Rollback();
                        throw ex;
                    }

                }
                cmd.CommandText = "spIncrementaBalanceCuenta";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_idCuenta", idCuenta);
                cmd.Parameters.AddWithValue("p_monto", Convert.ToDecimal(txtSubtotal.Text));
                log.Info($"Incrementando balance de la cuenta {idCuenta}...");
                cmd.ExecuteNonQuery();

                transaction.Commit();
                log.Info($"Balance de la cuenta {idCuenta} incrementado ${txtSubtotal.Text}");
                conn.Close();

                MessageBox.Show("Se ha registrado la factura con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                log.Error("Algo salió mal", ex);
                MessageBox.Show("Algo salió mal", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, ex.Source);
            };
        }
    }
}
