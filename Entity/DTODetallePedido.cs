using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DTODetallePedido
    {
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public int PrecioUnidad { get; set; }
        public int Descuento { get; set; }
    }
}
