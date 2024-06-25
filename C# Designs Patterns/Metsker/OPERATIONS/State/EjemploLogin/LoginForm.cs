using System;
using System.Windows.Forms;

namespace EjemploLogin
{
    public partial class LoginForm : Form
    {
        private LoginContext loginContext;

        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += LoginButton_Click;
            loginContext = new LoginContext();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Aquí se debería verificar el usuario y la clave.
            // Para este ejemplo, asumimos que siempre fallan.

            if (txtUsername.Text == "user" && txtPassword.Text == "password")
            {
                MessageBox.Show("Login exitoso!");
                loginContext = new LoginContext(); // Reiniciar el contexto después de un login exitoso
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                loginContext.Request();
                if (loginContext.Attempts >= 3)
                {
                    // Deshabilitar el botón de login si la cuenta está bloqueada
                    btnLogin.Enabled = false;
                }
            }
        }
    }

    //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    /* *************************************************************************
    Primero, definimos:
    *) una interfaz para los estados
    *) las clases que representarán cada estado del login
    ************************************************************************* */

    public interface ILoginState
    {
        void Handle(LoginContext context);
    }

    // InitialState resetea los intentos a cero y cambia al estado ActiveState.
    public class InitialState : ILoginState
    {
        public void Handle(LoginContext context)
        {
            context.Attempts = 0;
            context.SetState(new ActiveState());
        }
    }

    // ActiveState incrementa los intentos y cambia al estado LockedState si los
    // intentos llegan a 3.
    public class ActiveState : ILoginState
    {
        public void Handle(LoginContext context)
        {
            context.Attempts++;
            if (context.Attempts >= 3)
            {
                context.SetState(new LockedState());
            }
        }
    }

    // LockedState muestra un mensaje indicando que la cuenta está bloqueada.
    public class LockedState : ILoginState
    {
        public void Handle(LoginContext context)
        {
            MessageBox.Show("La cuenta está bloqueada.");
        }
    }


    /* *************************************************************************
    Contexto del Login
    La clase LoginContext que mantendrá el estado actual del login y permitirá
    la transición entre estados.
    ************************************************************************* */

    public class LoginContext
    {
        private ILoginState _state;
        public int Attempts { get; set; }

        public LoginContext()
        {
            _state = new InitialState();
            _state.Handle(this);
        }

        public void SetState(ILoginState state)
        {
            _state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }




}
