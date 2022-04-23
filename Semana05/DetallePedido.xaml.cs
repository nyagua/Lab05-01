using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using Business;
namespace Semana04
{
    /// <summary>
    /// Interaction logic for DetallePedido.xaml
    /// </summary>
    /// 
    public partial class DetallePedido : Window
    {
        private Pedido pedido;

        public DetallePedido(Pedido pedido)
        {
            this.pedido = pedido;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            BDetallePedido bDetallePedido = new BDetallePedido();
            List<Entity.DetallePedido> detalles = bDetallePedido.GetDetallePedidosPorId(this.pedido.IdPedido);
            dgvPedido.ItemsSource = bDetallePedido.dTODetallePedidos(detalles);
            txtTotal.Text = bDetallePedido.GetDetalleTotal(detalles).ToString();
        }
    }
}
