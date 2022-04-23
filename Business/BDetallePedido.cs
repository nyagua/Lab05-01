using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;
namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DDetallePedido = null;
        public List<DetallePedido> GetDetallePedidosPorId(int IdPedido)
        {
            List<DetallePedido> DetallePedidos = null;
            try
            {
                DDetallePedido = new DDetallePedido();
                DetallePedidos = DDetallePedido.GetDetallePedidos(new DetallePedido { Pedido = new Pedido { IdPedido = IdPedido } }) ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return DetallePedidos;
        }

        public List<DTODetallePedido> dTODetallePedidos(List<DetallePedido> detalles)
        {
            List<DTODetallePedido> dTODetallePedidos = new List<DTODetallePedido>();
            foreach (var detalle in detalles)
            {
                dTODetallePedidos.Add(new DTODetallePedido {
                    IdPedido = detalle.Pedido.IdPedido,
                    IdProducto = detalle.IdProducto,
                    Cantidad = detalle.Cantidad,
                    Descuento = detalle.Descuento,
                    PrecioUnidad = detalle.PrecioUnidad
                });
            }
            return dTODetallePedidos;
        }

        public decimal GetDetalleTotal(List<DetallePedido> detalles)
        {
            decimal total = 0;

            foreach (var item in detalles)
            {
                total = total + item.Cantidad * item.PrecioUnidad - item.Descuento;
            }
            
            return total;
        }
    }
}
