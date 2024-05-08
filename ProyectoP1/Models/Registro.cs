using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoP1.Models
{
    public class Registro
    {
		public int Id { get; set; }
		public int ClienteId { get; set; }
		[ForeignKey("ClienteId")]
		public Cliente? Cliente { get; set; }
		public int VehiculoId { get; set; }
		[ForeignKey("VehiculoId")]
		public Vehiculo? Vehiculo { get; set; }
		public String Estatus { get; set; }
		public DateTime FechaHora { get; set; }
	}

}
