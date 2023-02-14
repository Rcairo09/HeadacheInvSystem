using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeadacheInvSystem.Models
{
    public partial class OrdenVentum
    {
        [DisplayName("Id")]
        public byte OrdenId { get; set; }
        [DisplayName("Producto")]
        public byte ProductoId { get; set; }
        [DisplayName("Nombre Cliente")]
        public string NombreCliente { get; set; } = null!;
        [DisplayName("Apellido Cliente")]
        public string? ApellidoCliente { get; set; }
        [DisplayName("Correo")]
        public string? Correo { get; set; }

        public virtual Producto Producto { get; set; } = null!;
    }
}
