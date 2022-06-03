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

namespace penerima_manfaat
{
    /// <summary>
    /// Interaction logic for menu.xaml
    /// </summary>
    public partial class menu : Window
    {
        public menu()
        {
            InitializeComponent();
        }

        private void penerima_Click(object sender, RoutedEventArgs e)
        {
            MainWindow penerima = new MainWindow();
            penerima.Show();
            this.Close();
        }

        private void asessor_Click(object sender, RoutedEventArgs e)
        {
            Window1 asessor = new Window1();
            asessor.Show();
            this.Close();
        }

        private void kategori_Click(object sender, RoutedEventArgs e)
        {
            kategori kategori = new kategori();
            kategori.Show();
            this.Close();
        }
    }
}
