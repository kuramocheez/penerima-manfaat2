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
    public class Asessor
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string jenisKelamin { get; set; }
        public string nomorTelpon { get; set; }
    }
    /// <summary>
    /// Interaction logic for asessor.xaml
    /// </summary>
    public partial class asessor : Window
    {
        public asessor()
        {
            InitializeComponent();
        }
    }
}
