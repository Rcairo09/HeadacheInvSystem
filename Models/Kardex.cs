using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeadacheInvSystem.Models
{
    public partial class Kardex
    {
        [DisplayName("Id")]
        public byte KardexId { get; set; }
        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }
        [DisplayName("Producto")]
        public byte ProductoId { get; set; }
        [DisplayName("Entradas")]
        public short Entradas { get; set; }
        [DisplayName("Salidas")]
        public short Salidas { get; set; }
        [DisplayName("Existencias")]
        public short Existencias { get; set; }
        [DisplayName("Compra")]
        public decimal Compra { get; set; }
        [DisplayName("Costo Promedio")]
        public decimal CostoPromedio { get; set; }
        [DisplayName("Debe")]
        public decimal Debe { get; set; }
        [DisplayName("Haber")]
        public decimal Haber { get; set; }
        [DisplayName("Saldo")]
        public decimal Saldo { get; set; }

        public virtual Producto Producto { get; set; } = null!;
    }
}
