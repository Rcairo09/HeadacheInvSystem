using System;
using System.Collections.Generic;

namespace HeadacheInvSystem.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public byte CategoriaId { get; set; }
        public string NombreCategoria { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
