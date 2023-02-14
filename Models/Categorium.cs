using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeadacheInvSystem.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }
        [DisplayName("Id")]
        public byte CategoriaId { get; set; }
        [DisplayName("Categoría")]
        public string NombreCategoria { get; set; } = null!;
        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
