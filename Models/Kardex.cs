using System;
using System.Collections.Generic;

namespace HeadacheInvSystem.Models
{
    public partial class Kardex
    {
        public byte KardexId { get; set; }
        public DateTime Fecha { get; set; }
        public byte ProductoId { get; set; }
        public short Entradas { get; set; }
        public short Salidas { get; set; }
        public short Existencias { get; set; }
        public decimal Compra { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Saldo { get; set; }

        public virtual Producto Producto { get; set; } = null!;
    }
}
