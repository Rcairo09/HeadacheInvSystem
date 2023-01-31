using System;
using System.Collections.Generic;

namespace HeadacheInvSystem.Models
{
    public partial class ClientesProducto
    {
        public byte? ClienteId { get; set; }
        public byte? ProductoId { get; set; }
        public string? NombreCliente { get; set; }
    }
}
