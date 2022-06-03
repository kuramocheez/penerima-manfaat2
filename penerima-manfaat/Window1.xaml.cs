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
using PenerimaManfaatAPI;
using System.Data;

namespace penerima_manfaat
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public class assessor
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string jenisKelamin { get; set; }
        public string nomorTelpon { get; set; }
    }
    public partial class Window1 : Window
    {
        APIPenerimaManfaat dao = new APIPenerimaManfaat();
        string id = null;
        public Window1()
        {
            InitializeComponent();
            initDataView();
        }
        public void initDataView()
        {
            dataGrid.DataContext = dao.getAsessor();
        }

        private void btnPenerimaManfaat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        private void btnKategori_Click(object sender, RoutedEventArgs e)
        {
            menu kt = new menu();
            kt.Show();
            this.Close();
        }

        private void clear()
        {
            id = null;
            nama.Text = "";
            jenisKelamin.Text = "";
            noTelp1.Text = "";
        }
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            assessor assessor = new assessor();
            assessor.nama = nama.Text;
            assessor.jenisKelamin = jenisKelamin.Text;
            assessor.nomorTelpon = noTelp1.Text;
            dao.tambahAsessor(assessor.nama, assessor.jenisKelamin, assessor.nomorTelpon);
            MessageBox.Show("Data Asessor Berhasil Ditambahkan");
            clear();
            initDataView();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            assessor assessor = new assessor();
            assessor.nama = nama.Text;
            assessor.jenisKelamin = jenisKelamin.Text;
            assessor.nomorTelpon = noTelp1.Text;
            dao.ubahAsessor(assessor.nama, assessor.jenisKelamin, assessor.nomorTelpon, id);
            MessageBox.Show("Data Asessor Berhasil DiUbah");
            clear();
            initDataView();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)dataGrid.SelectedItem;
            id = dr["ID"].ToString();
            nama.Text = dr["Nama"].ToString();
            jenisKelamin.Text = dr["Jenis Kelamin"].ToString();
            noTelp1.Text = dr["Nomor Telpon"].ToString();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            dao.hapusAsessor(id);
            MessageBox.Show("Data Asessor Berhasil DiHapus");
            clear();
            initDataView();
        }
    }
    
}
