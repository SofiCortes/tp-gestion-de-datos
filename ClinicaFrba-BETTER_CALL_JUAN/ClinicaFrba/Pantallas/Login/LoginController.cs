using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class LoginController
    {
        private LoginForm loginForm;

        public LoginController(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }


        internal void loginUser(string username, string password)
        {
            LoginManager loginManager = new LoginManager();
            loginManager.loginUser(username, password);
        }
    }
}
