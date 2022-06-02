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
using System.Data;
using PenerimaManfaatAPI;

namespace penerima_manfaat
{
    public class Kategori
    {
        public string id { get; set; }
        public string kategoti { get; set; }
        public string nominalPaket { get; set; }
    }
    /// <summary>
    /// Interaction logic for kategori.xaml
    /// </summary>
    public partial class kategori : Window
    {
        APIPenerimaManfaat dao = new APIPenerimaManfaat();
        public kategori()
        {
            InitializeComponent();
            InitDataView();

        }
        public void InitDataView()
        {
            //DataSet data = dao.getKategori();
            //dataGrid.DataContext = data;
        }
    }
}
