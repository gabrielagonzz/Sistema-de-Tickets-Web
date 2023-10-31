using Practica4.Interfaces;

namespace Practica4.Models
{
    public class Reporte : IReporte
    {
        public string Usuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int Id { get; set; }

        public Reporte(string usuario, string tipoUsuario, string descripcion)
        {
            this.Usuario = usuario;
            this.TipoUsuario = tipoUsuario;
            this.Descripcion = descripcion;
            this.Fecha = DateTime.Now;
        }
    }
}
