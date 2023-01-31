using System;
using System.Collections.Generic;

namespace HeadacheInvSystem.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Kardices = new HashSet<Kardex>();
            OrdenVenta = new HashSet<OrdenVentum>();
        }

        public byte ProductoId { get; set; }
        public byte CategoriaId { get; set; }
        public byte ProveedorId { get; set; }
        public string ProductoNombre { get; set; } = null!;
        public decimal ProductoPrecioUnitario { get; set; }

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual Proveedor Proveedor { get; set; } = null!;
        public virtual ICollection<Kardex> Kardices { get; set; }
        public virtual ICollection<OrdenVentum> OrdenVenta { get; set; }
    }
}
