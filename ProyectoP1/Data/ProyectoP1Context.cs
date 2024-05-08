using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoP1.Models;

namespace ProyectoP1.Data
{
    public class ProyectoP1Context : DbContext
    {
        public ProyectoP1Context (DbContextOptions<ProyectoP1Context> options)
            : base(options)
        {
        }

        public DbSet<ProyectoP1.Models.Registro> Registro { get; set; } = default!;
        public DbSet<ProyectoP1.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<ProyectoP1.Models.Vehiculo> Vehiculo { get; set; } = default!;
        public DbSet<ProyectoP1.Models.Cliente> Cliente { get; set; } = default!;
    }
}
