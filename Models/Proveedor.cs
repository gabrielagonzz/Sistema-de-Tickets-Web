using Practica4.Interfaces;

namespace Practica4.Models
{
    public class Proveedor : IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }

        public Proveedor(string nombre, string contraseña, List<IUsuario> lista)
        {
            this.Nombre = nombre;
            this.Contraseña = contraseña;
            this.Id = CrearID(lista);
            this.Rol = 1;
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
