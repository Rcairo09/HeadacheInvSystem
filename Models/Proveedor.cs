using System;
using System.Collections.Generic;

namespace HeadacheInvSystem.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public byte ProveedorId { get; set; }
        public string Nombre { get; set; } = null!;
        public int? Celular { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
