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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;
namespace Semana04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                List<Pedido> bPedidos = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text));
                dgvPedido.ItemsSource = bPedidos;
                txtTotal.Text = bPedidos.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el administrador "+ex.ToString());
            }
            finally
            {
                bPedido = null;
            }
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Pedido pedido = dgvPedido.SelectedItem as Pedido;
            DetallePedido detallePedido = new DetallePedido(pedido);
            detallePedido.Show();
        }
    }
}
