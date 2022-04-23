using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos(DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<DetallePedido> detalles = null;
            try
            {
                commandText = "USP_DETALLEPEDIDO";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@PedidoId", SqlDbType.Int);
                parameters[0].Value = detallePedido.Pedido.IdPedido;
                detalles = new List<DetallePedido>();
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "USP_DETALLEPEDIDO",
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetallePedido {
                            Pedido = detallePedido.Pedido,
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Cantidad = reader["Cantidad"] != null ? Convert.ToInt32(reader["Cantidad"]) : 0,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToInt32(reader["PrecioUnidad"]) : 0,
                            Descuento = reader["Descuento"] != null ? Convert.ToInt32(reader["Descuento"]) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return detalles;
        }
    }
}
