namespace Practica4.Interfaces
{
    public interface IReporte
    {
        string Usuario { get; }
        string TipoUsuario { get; }
        string Descripcion { get; }
        public DateTime Fecha { get; }
        int Id { get; }
    }
}
