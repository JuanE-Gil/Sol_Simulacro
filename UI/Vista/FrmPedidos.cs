using System;
using System.Windows.Forms;

using UI.Controlador;
using UI.Modelo;

namespace UI.Vista
{
    public partial class FrmPedidos : Form
    {
        private readonly PedidoControlador pedidosDb = new PedidoControlador();
        private readonly ClienteControlador clienteDb = new ClienteControlador();
        private readonly ProductosControlador productosDb = new ProductosControlador();
        private readonly RepVentasControlador repVentasDb = new RepVentasControlador();

        public FrmPedidos() {
            InitializeComponent();
            CargarDatos();
        }

        private void BtnGuardar_Click(object sender, System.EventArgs e) {
            decimal numPedido = Convert.ToDecimal(txtNumPedido.Text);
            DateTime fechaPedido = DtpFechaPedido.Value;
            decimal cliente = Convert.ToDecimal(CboCliente.SelectedValue);
            decimal rep = Convert.ToDecimal(CboRep.SelectedValue);
            string fab = Convert.ToString(CboFab.SelectedValue);
            string producto = Convert.ToString(CboProducto.SelectedValue);
            decimal cant = Convert.ToDecimal(txtCantidad.Text);
            double importe = Convert.ToDouble(txtNumPedido.Text);

            Pedidos pedidos = new Pedidos(numPedido, fechaPedido, cliente, rep, fab, producto, cant, importe);
            pedidosDb.Insert(pedidos);

            MessageBox.Show("¡Nuevo Pedido Registrado!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarDatos();
        }
        private void BtnActualizar_Click(object sender, EventArgs e) {
            decimal numPedido = Convert.ToDecimal(txtNumPedido.Text);
            DateTime fechaPedido = DtpFechaPedido.Value;
            decimal cliente = Convert.ToDecimal(CboCliente.SelectedValue);
            decimal rep = Convert.ToDecimal(CboRep.SelectedValue);
            string fab = Convert.ToString(CboFab.SelectedValue);
            string producto = Convert.ToString(CboProducto.SelectedValue);
            decimal cant = Convert.ToDecimal(txtCantidad.Text);
            double importe = Convert.ToDouble(txtNumPedido.Text);

            Pedidos pedidos = new Pedidos(numPedido, fechaPedido, cliente, rep, fab, producto, cant, importe);
            pedidosDb.update(pedidos);

            MessageBox.Show("¡Pedido Actualizado!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarDatos();
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar este Pedido?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                pedidosDb.Delete(Convert.ToInt32(txtNumPedido.Text));
                MessageBox.Show("Pedido eliminado exitosamente!", "Mensaje",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
            }
        }

        private void FrmPedidos_Load(object sender, System.EventArgs e) {
            Refrescar();
        }

        private void Refrescar() {
            DgvPedidos.DataSource = pedidosDb.FindAll();
        }

        private void CargarDatos() {
            // ComboBox de Cliente
            CboCliente.DataSource = clienteDb.FindAll();
            CboCliente.ValueMember = "num_clie";
            CboCliente.DisplayMember = "empresa";

            //ComboBox de RepVentas
            CboRep.DataSource = repVentasDb.FindAll();
            CboRep.ValueMember = "num_empl";
            CboRep.DisplayMember = "num_empl";

            //ComboBox de fab
            CboFab.DataSource = productosDb.FindAll();
            CboFab.ValueMember = "id_fab";
            CboFab.DisplayMember = "id_fab";

            //ComboBox de Producto
            CboProducto.DataSource = productosDb.FindAll();
            CboProducto.ValueMember = "id_producto";
            CboProducto.DisplayMember = "id_producto";
        }

        private void DgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e) {
            this.Selecciona_Pedido();
            BtnActualizar.Visible = true;
            BtnEliminar.Enabled = true;
        }

        private void Selecciona_Pedido() {
            if (string.IsNullOrEmpty(Convert.ToString(DgvPedidos.CurrentRow.Cells["num_pedido"].Value))) {
                MessageBox.Show("No se tiene informacion para visualizar",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            } else {
                txtNumPedido.Text = DgvPedidos.CurrentRow.Cells["num_pedido"].Value.ToString();
                DtpFechaPedido.Text = Convert.ToString(DgvPedidos.CurrentRow.Cells["fecha_pedido"].Value);
                CboCliente.Text = Convert.ToString(DgvPedidos.CurrentRow.Cells["clie"].Value);
                CboRep.Text = Convert.ToString(DgvPedidos.CurrentRow.Cells["rep"].Value);
                CboFab.Text = Convert.ToString(DgvPedidos.CurrentRow.Cells["fab"].Value);
                txtCantidad.Text = DgvPedidos.CurrentRow.Cells["cant"].Value.ToString();
                txtImporte.Text = DgvPedidos.CurrentRow.Cells["importe"].Value.ToString();
            }
        }

        private void LimpiarDatos() {
            txtNumPedido.Text = null;
            DtpFechaPedido.Value = DateTime.Today;
            CboCliente.SelectedIndex = 0;
            CboRep.SelectedIndex = 0;
            CboFab.SelectedIndex = 0;
            CboProducto.SelectedIndex = 0;
            txtCantidad.Text = null;
            txtImporte.Text = null;
            txtNumPedido.Focus();

            Refrescar();
            BtnEliminar.Enabled = false;
            BtnActualizar.Visible = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e) {
            LimpiarDatos();
            BtnEliminar.Enabled = false;
            BtnActualizar.Visible = false;
        }

        private void FrmPedidos_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
