using System;
using System.Collections.Generic;

namespace HeadacheInvSystem.Models
{
    public partial class OrdenVentum
    {
        public byte OrdenId { get; set; }
        public byte ProductoId { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? ApellidoCliente { get; set; }
        public string? Correo { get; set; }

        public virtual Producto Producto { get; set; } = null!;
    }
}
