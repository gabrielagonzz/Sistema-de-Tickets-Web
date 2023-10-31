using Practica4.Interfaces;

namespace Practica4.Services
{
    public class Login
    {
        private List<IUsuario> usuarios = new List<IUsuario>();
        private DatoUsuario datoUsuario = new DatoUsuario();

        public int LoginStart(string usuario, string password)
        {
            usuarios = datoUsuario.ObtenerUsuario();

            IUsuario usuarioLog = usuarios.Find(u => u.Nombre == usuario);

            if (usuarioLog != null && usuarioLog.Contraseña == password)
            {
                return usuarioLog.Rol;
            }
            else
            {
                return 0;
            }
        }
    }
}
