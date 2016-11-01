using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class LoginController : SeleccionarRolListener
    {
        private static int NO_EXISTE_EL_USUARIO_LOGIN_RESULT = -1;
        private static int USUARIO_INHABILITADO_LOGIN_RESULT = -2;
        private static int CONTRASENIA_INCORRECTA_LOGIN_RESULT = -3;
        private static int LOGIN_OK_1_ROL_LOGIN_RESULT = 1;
        private static int LOGIN_OK_MAS_DE_1_ROL_LOGIN_RESULT = 2;

        private LoginForm loginForm;

        public LoginController(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }


        internal void loginUser(string username, string password)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            decimal loginResult = usuarioManager.loginUser(username, password);

            if (loginResult == NO_EXISTE_EL_USUARIO_LOGIN_RESULT)
            {
                loginForm.ShowErrorDialog("No existe el usuario");
            }
            else if (loginResult == USUARIO_INHABILITADO_LOGIN_RESULT)
            {
                loginForm.ShowErrorDialog("Usuario inhabilitado");
            }
            else if (loginResult == CONTRASENIA_INCORRECTA_LOGIN_RESULT)
            {
                loginForm.ShowErrorDialog("Contraseña incorrecta");
            }
            else
            {
                UsuarioConfiguracion.getInstance().setUsuarioId(loginResult);
                this.getRolesDeUsuario(username);
            }
        }

        public void getRolesDeUsuario(string username)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            List<Rol> roles = usuarioManager.getRolesDeUsuario(username);
            if (roles != null)
            {
                if (roles.Count() == 1)
                {
                    this.getFuncionalidadesParaRol(roles.ElementAt(0));
                }
                else
                {
                    this.loginForm.mostrarDialogoSeleccionRol(roles);       
                }
            }
            else
            {
                loginForm.ShowErrorDialog("Ocurrio un error al obtener los roles del usuario. Por favor intentelo de nuevo.");
            }
        }

        private void getFuncionalidadesParaRol(Rol rol)
        {
            RolManager rolManager = new RolManager();
            List<String> funcionalidades = rolManager.getFuncionalidadesDeRol(rol.nombre);

            if (funcionalidades != null)
            {
                UsuarioConfiguracion.getInstance().addFuncionalidades(funcionalidades);
                this.loginForm.showPantallaPrincipal();
            }
            else
            {
                loginForm.ShowErrorDialog("Ocurrio un error al obtener las funcionalidades del usuario. Por favor intentelo de nuevo.");
            }
        }

        public void rolSeleccionado(Rol rol)
        {
            this.getFuncionalidadesParaRol(rol);
        }
    }
}
