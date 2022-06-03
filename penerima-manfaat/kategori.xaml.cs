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
        public string kategori { get; set; }
        public string nominalPaket { get; set; }
    }
    /// <summary>
    /// Interaction logic for kategori.xaml
    /// </summary>
    public partial class kategori : Window
    {
        string id = null;
        APIPenerimaManfaat dao = new APIPenerimaManfaat();
        public kategori()
        {
            InitializeComponent();
            InitDataView();

        }
        public void InitDataView()
        {
            dataGrid.DataContext = dao.getKategori();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            Kategori kt = new Kategori();
            kt.kategori = kategori1.Text;
            kt.nominalPaket = nominalPaket.Text;
            dao.tambahKategori(kt.kategori, kt.nominalPaket);
            MessageBox.Show("Berhasil Menambahkan Data Kategori");
            clear();
            InitDataView();
        }

        public void clear()
        {
            id = null;
            kategori1.Text = "";
            nominalPaket.Text = "";
        }
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)dataGrid.SelectedItem;
            id = dr["ID"].ToString();
            kategori1.Text = dr["kategori"].ToString();
            nominalPaket.Text = dr["Nominal Paket"].ToString();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            Kategori kt = new Kategori();
            kt.kategori = kategori1.Text;
            kt.nominalPaket = nominalPaket.Text;
            dao.ubahKatgori(kt.kategori, kt.nominalPaket, id);
            MessageBox.Show("Berhasil Mengubah Data Kategori");
            clear();
            InitDataView();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            dao.hapusKategori(id);
            MessageBox.Show("Berhasil Menghapus Data Kategori");
            clear();
            InitDataView();
        }

        private void btnPenerimaManfaat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void btnAsessor_Click(object sender, RoutedEventArgs e)
        {
            menu w = new menu();
            w.Show();
            this.Close();
        }
    }
}
