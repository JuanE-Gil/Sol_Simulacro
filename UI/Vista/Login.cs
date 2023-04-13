using System;
using System.Windows.Forms;

namespace UI.Vista
{
    public partial class Login : Form
    {
        private int intentos = 3;
        public Login() {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e) {
            string username = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (username == "Juan" && password == "12345678") {
                FrmPedidos pedidos = new FrmPedidos();

                MessageBox.Show("¡Bienvenido al Sistema!", "¡Ingreso Exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                pedidos.Show();

            } else {
                intentos--;
                if (intentos > 0) {
                    lblError.Text = "Acceso Denegado. Intentos restantes: " + intentos.ToString();
                    lblError.Visible = true;

                    txtUsuario.Text = "";
                    txtContrasena.Text = "";
                    txtUsuario.Focus();
                } else {
                    MessageBox.Show("Se han agotado los intentos. El programa se cerrará.", "Acceso Denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }
    }
}
