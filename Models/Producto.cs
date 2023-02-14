using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeadacheInvSystem.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Kardices = new HashSet<Kardex>();
            OrdenVenta = new HashSet<OrdenVentum>();
        }
        [DisplayName("Id")]
        public byte ProductoId { get; set; }
        [DisplayName("Categoría")]
        public byte CategoriaId { get; set; }
        [DisplayName("Proveedor")]
        public byte ProveedorId { get; set; }
        [DisplayName("Producto")]
        public string ProductoNombre { get; set; } = null!;
        [DisplayName("Precio Unitario")]
        public decimal ProductoPrecioUnitario { get; set; }

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual Proveedor Proveedor { get; set; } = null!;
        public virtual ICollection<Kardex> Kardices { get; set; }
        public virtual ICollection<OrdenVentum> OrdenVenta { get; set; }
    }
}
