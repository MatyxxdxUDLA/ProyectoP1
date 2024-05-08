using System.ComponentModel.DataAnnotations;

namespace ProyectoP1.Models
{
	public class Cliente
	{
		[Key]
		public int Id { get; set; }
		public string Cedula { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
	}
}
