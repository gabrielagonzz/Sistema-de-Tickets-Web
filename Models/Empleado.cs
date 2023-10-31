using Practica4.Interfaces;

namespace Practica4.Models
{
    public class Empleado : IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }

        public Empleado(string nombre, string contraseña, List<IUsuario> lista)
        {
            this.Nombre = nombre;
            this.Contraseña = contraseña;
            this.Id = CrearID(lista);
            this.Rol = 2;
        }
        public int CrearID(List<IUsuario> lista)
        {
            if (lista.Any() == false)
            {
                return 1;
            }
            else
            {
                return lista.Last().Id + 1;
            }
        }
    }
}
