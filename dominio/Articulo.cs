using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int ID { get; set; }
        // nombre que se muestra en la columna
        [DisplayName("Código")]
        public string codArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Elemento Marca { get; set; }
        public Elemento Categoria { get; set; }
        public string Imagen { get; set; }
        public Decimal Precio { get; set; }
    }
}
