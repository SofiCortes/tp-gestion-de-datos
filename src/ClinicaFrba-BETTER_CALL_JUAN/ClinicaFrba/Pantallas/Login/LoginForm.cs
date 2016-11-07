using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class LoginForm : Form
    {
        private LoginController loginController;

        public LoginForm()
        {
            InitializeComponent();

            loginController = new LoginController(this);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
               
            string username = this.textBoxUsername.Text;
            string password = this.textBoxPassword.Text;

            loginController.loginUser(username, password);
        }

        internal void ShowErrorDialog(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void mostrarDialogoSeleccionRol(List<Rol> roles)
        {
            SeleccionarRol Form = new SeleccionarRol();
            Form.setSeleccionarRolListener(this.loginController);
            Form.setRoles(roles);
            Form.ShowDialog();
        }

        internal void showPantallaPrincipal()
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Dispose();
        }

        private void LoginFom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
