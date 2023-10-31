using Practica4.Interfaces;

namespace Practica4.Models
{
    public class Usuario : IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }

        public int CrearID(List<IUsuario> lista)
        {
            if (lista.Any() == false)
            {
                return 1;
            }
            else
            {
                return lista.Max(u => ((Usuario)u).Id) + 1;
            }
        }
    }
}
