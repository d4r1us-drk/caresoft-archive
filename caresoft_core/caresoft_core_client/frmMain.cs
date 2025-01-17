using caresoft_core_client.Aseguradora;
using caresoft_core_client.Inventario;
using caresoft_core_client.Proveedor;
using caresoft_core_client.Servicios;
using caresoft_core_client.Usuario;

namespace caresoft_core_client;

public partial class frmMain : Form
{
    private frmLogin loginForm;

    private frmInventarioRegistrarProducto frmInventarioRegistrarProducto;
    private frmInventarioActualizarProducto frmInventarioActualizarProducto;
    private frmInventarioEliminarProducto frmInventarioEliminarProducto;
    private frmInventarioConsultaProductos frmInventarioConsultaProductos;

    private frmInventarioAnadirProveedor frmInventarioRegistrarProveedor;
    private frmInventarioActualizarProveedor frmInventarioActualizarProveedor;
    private frmInventarioEliminarProveedor frmInventarioEliminarProveedor;
    private frmInventarioConsultaProveedor frmInventarioConsultaProveedores;

    private frmServiciosAnadirTipoServicio frmServiciosAnadirTipoServicio;
    private frmServiciosActualizarTipoServicio frmServiciosActualizarTipoServicio;
    private frmServiciosEliminarTipoServicio frmServiciosEliminarTipoServicio;
    private frmServiciosConsultarTipoServicio frmServiciosConsultarTipoServicio;

    private frmServiciosActualizarServicio frmServiciosActualizarServicio;
    private frmServiciosAnadirServicio frmServiciosAnadirServicio;
    private frmServiciosEliminarServicio frmServiciosEliminarServicio;
    private frmServiciosConsultarServicio frmServiciosConsultarServicio;

    private frmAseguradoraRegistrarAseguradora frmAseguradoraRegistrarAseguradora;
    private frmAseguradoraActualizarAseguradora frmAseguradoraActualizarAseguradora;
    private frmAseguradoraEliminarAseguradora frmAseguradoraEliminarAseguradora;
    private frmAseguradoraConsultarAseguradora frmAseguradoraConsultarAseguradora;

    private frmHospitalesActualizarSucursal frmHospitalesActualizarSucursal;
    private frmHospitalesRegistrarSucursal frmHospitalesRegistrarSucursal;
    private frmHospitalesEliminarSucursal frmHospitalesEliminarSucursal;

    private frmUsuarioRegistrar frmUsuarioRegistrar;
    private frmUsuarioActualizar frmUsuarioActualizar;
    private frmUsuarioEliminar frmUsuarioEliminar;
    private frmUsuarioConsultar frmUsuarioConsultar;

    private frmReporteConsultas frmReporteConsultas;
    private frmReporteIngresos frmReporteIngresos;
    private frmReporteFacturas frmReporteFacturas;

    private string baseURL;

    public frmMain(string baseURL)
    {
        InitializeComponent();
        this.baseURL = baseURL;
    }

    private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    public void SetLoginForm(frmLogin loginForm)
    {
        this.loginForm = loginForm;
    }

    private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        loginForm.Show();
        Hide();
    }

    private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void anadirProductoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioRegistrarProducto = new(baseURL);
        frmInventarioRegistrarProducto.MdiParent = this;
        frmInventarioRegistrarProducto.Show();
    }

    private void actualizarProductoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioActualizarProducto = new(baseURL);
        frmInventarioActualizarProducto.MdiParent = this;
        frmInventarioActualizarProducto.Show();
    }

    private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioEliminarProducto = new(baseURL);
        frmInventarioEliminarProducto.MdiParent = this;
        frmInventarioEliminarProducto.Show();

    }

    private void consultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioConsultaProductos = new(baseURL);
        frmInventarioConsultaProductos.MdiParent = this;
        frmInventarioConsultaProductos.Show();
    }

    private void anadirProveedorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioRegistrarProveedor = new(baseURL);
        frmInventarioRegistrarProveedor.MdiParent = this;
        frmInventarioRegistrarProveedor.Show();
    }

    private void actualizarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioActualizarProveedor = new(baseURL);
        frmInventarioActualizarProveedor.MdiParent = this;
        frmInventarioActualizarProveedor.Show();
    }

    private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioEliminarProveedor = new(baseURL);
        frmInventarioEliminarProveedor.MdiParent = this;
        frmInventarioEliminarProveedor.Show();

    }

    private void consultarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmInventarioConsultaProveedores = new(baseURL);
        frmInventarioConsultaProveedores.MdiParent = this;
        frmInventarioConsultaProveedores.Show();
    }

    private void anadirTipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosAnadirTipoServicio = new(baseURL);
        frmServiciosAnadirTipoServicio.MdiParent = this;
        frmServiciosAnadirTipoServicio.Show();
    }

    private void actualizarTipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosActualizarTipoServicio = new(baseURL);
        frmServiciosActualizarTipoServicio.MdiParent = this;
        frmServiciosActualizarTipoServicio.Show();
    }

    private void eliminarTipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosEliminarTipoServicio = new(baseURL);
        frmServiciosEliminarTipoServicio.MdiParent = this;
        frmServiciosEliminarTipoServicio.Show();
    }

    private void anadirServicioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosAnadirServicio = new(baseURL);
        frmServiciosAnadirServicio.MdiParent = this;
        frmServiciosAnadirServicio.Show();
    }

    private void actualizarServicioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosActualizarServicio = new(baseURL);
        frmServiciosActualizarServicio.MdiParent = this;
        frmServiciosActualizarServicio.Show();
    }

    private void eliminarServicioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosEliminarServicio = new(baseURL);
        frmServiciosEliminarServicio.MdiParent = this;
        frmServiciosEliminarServicio.Show();
    }

    private void consultaDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosConsultarServicio = new(baseURL);
        frmServiciosConsultarServicio.MdiParent = this;
        frmServiciosConsultarServicio.Show();
    }

    private void consultaTipoDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmServiciosConsultarTipoServicio = new(baseURL);
        frmServiciosConsultarTipoServicio.MdiParent = this;
        frmServiciosConsultarTipoServicio.Show();
    }

    private void anadirAseguradoraToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmAseguradoraRegistrarAseguradora = new(baseURL);
        frmAseguradoraRegistrarAseguradora.MdiParent = this;
        frmAseguradoraRegistrarAseguradora.Show();
    }

    private void actualizarAseguradoraToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmAseguradoraActualizarAseguradora = new(baseURL);
        frmAseguradoraActualizarAseguradora.MdiParent = this;
        frmAseguradoraActualizarAseguradora.Show();
    }

    private void eliminarAseguradoraToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmAseguradoraEliminarAseguradora = new(baseURL);
        frmAseguradoraEliminarAseguradora.MdiParent = this;
        frmAseguradoraEliminarAseguradora.Show();
    }

    private void consultarAseguradorasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmAseguradoraConsultarAseguradora = new(baseURL);
        frmAseguradoraConsultarAseguradora.MdiParent = this;
        frmAseguradoraConsultarAseguradora.Show();
    }

    private void a˝adirSucursalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmHospitalesRegistrarSucursal = new(baseURL);
        frmHospitalesRegistrarSucursal.MdiParent = this;
        frmHospitalesRegistrarSucursal.Show();
    }

    private void actualizarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmHospitalesActualizarSucursal = new(baseURL);
        frmHospitalesActualizarSucursal.MdiParent = this;
        frmHospitalesActualizarSucursal.Show();
    }

    private void eliminarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmHospitalesEliminarSucursal = new(baseURL);
        frmHospitalesEliminarSucursal.MdiParent = this;
        frmHospitalesEliminarSucursal.Show();
    }

    private void a˝adirUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmUsuarioRegistrar = new(baseURL);
        frmUsuarioRegistrar.MdiParent = this;
        frmUsuarioRegistrar.Show();
    }

    private void actualizarDatosDeUnUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmUsuarioActualizar = new(baseURL);
        frmUsuarioActualizar.MdiParent = this;
        frmUsuarioActualizar.Show();
    }

    private void eliminarUnUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmUsuarioEliminar = new(baseURL);
        frmUsuarioEliminar.MdiParent = this;
        frmUsuarioEliminar.Show();
    }

    private void consultarDatosDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmUsuarioConsultar = new(baseURL);
        frmUsuarioConsultar.MdiParent = this;
        frmUsuarioConsultar.Show();
    }

    private void reportesDeConsultasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmReporteConsultas = new(baseURL);
        frmReporteConsultas.MdiParent = this;
        frmReporteConsultas.Show();
    }

    private void reportesDeIngresosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmReporteIngresos = new(baseURL);
        frmReporteIngresos.MdiParent = this;
        frmReporteIngresos.Show();
    }

    private void reportesDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmReporteFacturas = new(baseURL);
        frmReporteFacturas.MdiParent = this;
        frmReporteFacturas.Show();
    }
}
