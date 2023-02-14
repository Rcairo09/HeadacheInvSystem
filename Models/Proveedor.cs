using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeadacheInvSystem.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }
        [DisplayName("Id")]
        public byte ProveedorId { get; set; }
        [DisplayName("Proveedor")]
        public string Nombre { get; set; } = null!;
        [DisplayName("Celular")]
        public int? Celular { get; set; }
        [DisplayName("Correo")]
        public string? Correo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
