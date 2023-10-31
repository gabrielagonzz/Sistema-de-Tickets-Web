using Practica4.Interfaces;

namespace Practica4.Models
{
    public class Cliente : IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }

        public Cliente(string nombre, string contraseña, List<IUsuario> lista)
        {
            this.Nombre = nombre;
            this.Contraseña = contraseña;
            this.Id = CrearID(lista);
            this.Rol = 3;
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
