namespace ProyectoP1.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public DateTime FechaHora { get; set; }
        List<Usuario> UsuariosList { get; set; }
    }
}
