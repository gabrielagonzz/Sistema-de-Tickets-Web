namespace Practica4.Interfaces
{
    public interface IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }

        int CrearID(List<IUsuario> lista);
    }
}

