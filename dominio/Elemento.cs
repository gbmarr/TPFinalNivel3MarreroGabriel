using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Elemento
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        // socreescritura del metodo tostring para que me permita obtener y mostrar el dato descripcion dentro de la grilla
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
