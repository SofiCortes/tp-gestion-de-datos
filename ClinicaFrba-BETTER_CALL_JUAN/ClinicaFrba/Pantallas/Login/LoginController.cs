using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class LoginController
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
            LoginManager loginManager = new LoginManager();
            int loginResult = loginManager.loginUser(username, password);

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
                loginForm.ShowErrorDialog("Contrasena incorrecta");
            }
            else if (loginResult == LOGIN_OK_1_ROL_LOGIN_RESULT)
            {
                //Traer el rol???
            }
            else if (loginResult == LOGIN_OK_MAS_DE_1_ROL_LOGIN_RESULT)
            {
                //Traer los roles para seleccion??
            }
        }
    }
}
