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
using MySql.Data.MySqlClient;
using System.Data;

namespace penerima_manfaat
{
    public class PenerimaManfaat
    {
        public string nik { get; set; }
        public string kartuKeluarga { get; set; }
        public string nama { get; set; }
        public string tanggalLahir { get; set; }
        public string jenisKelamin { get; set; }
        public string agama { get; set; }
        public string kotaKabupaten { get; set; }
        public string alamat { get; set; }
        public string pekerjaan { get; set; }
        public string noTelpon{ get; set; }
        public string kriteria { get; set; }
        public string penghasilan { get; set; }
        public string golDarah { get; set; }
        public string status { get; set; }
        public string keterangan{ get; set; }
    }
    public class PenerimaManfaatDAO
    {
        private MySqlCommand cmd = null;
        MySqlConnection conn = new MySqlConnection();
        string conf = "Server= localhost; userid = root; password =; Database = penerima_manfaat";
        public PenerimaManfaatDAO()
        {
            conn.ConnectionString = conf;
        }
        public DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT nik as NIK, kartuKeluarga as `Nomor KK`, nama as Nama, DATE_FORMAT(tgl_lahir, '%d/%M/%Y') as `Tanggal Lahir`, jenis_kelamin as `Jenis Kelamin`, agama as Agama, kotaKabupaten, alamat as Alamat, pekerjaan as Pekerjaan, no_telp as `No. Telpon`, kriteria as Kriteria, penghasilan as Penghasilan, golDarah as `Golongan Darah`, status as Status, keterangan as Keterangan FROM data_penerimamanfaat";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                dataAdapter.Fill(ds, "data_penerimamanfaat");
                conn.Close();
            }
            catch(MySqlException e)
            {
                MessageBox.Show("Connection Problems When Get Data: " + e.Message, "Error");
            }
            return ds;
        }
        public bool InsertData(PenerimaManfaat pm)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO data_penerimamanfaat VALUES ('" + pm.nik + "','" + pm.kartuKeluarga + "','" + pm.nama + "','" + pm.tanggalLahir + "','" + pm.jenisKelamin + "','" + pm.agama + "','" + pm.kotaKabupaten + "','" + pm.alamat + "','" + pm.pekerjaan + "','" + pm.noTelpon + "','" + pm.kriteria + "','" + pm.penghasilan + "','" + pm.golDarah + "','" + pm.status + "','" + pm.keterangan + "')";
                cmd.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection Problems When Get Data: " + e.Message, "Error");
            }
            return status;
        }
        public bool DeleteData(string nik)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM data_penerimamanfaat WHERE nik = '" + nik + "'";
                cmd.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection Problems When Get Data: " + e.Message, "Error");
            }
            return status;
        }
        public bool UpdateData(PenerimaManfaat pm, string nik)
        {
            Boolean status = false;
            try
            {
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE data_penerimamanfaat SET kartuKeluarga = '"+pm.kartuKeluarga+ "', nama = '" + pm.nama + "', tgl_lahir = '" + pm.tanggalLahir + "', jenis_kelamin = '" + pm.jenisKelamin + "', agama = '" + pm.agama + "', kotaKabupaten = '" + pm.kotaKabupaten + "', alamat = '" + pm.alamat + "', pekerjaan = '" + pm.pekerjaan + "', no_telp = '" + pm.noTelpon + "', kriteria = '" + pm.kriteria + "', penghasilan = '" + pm.penghasilan + "', golDarah = '" + pm.golDarah + "', status = '" + pm.status + "', keterangan = '" + pm.keterangan + "' WHERE nik = '" + nik+"'";
                cmd.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Connection Problems When Get Data: " + e.Message, "Error");
            }
            return status;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PenerimaManfaatDAO dao = new PenerimaManfaatDAO();
        public MainWindow()
        {
            InitializeComponent();
            InitDataView();
            
        }
        public void InitDataView()
        {
            DataSet data = dao.getData();
            dataGrid.DataContext = data;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            nik.Text = "";
            kartuKeluarga.Text = "";
            nama.Text = "";
            tanggalLahir.Text = "";
            jenisKelamin.Text = "";
            agama.Text = "";
            kota.Text = "";
            alamat.Text = "";
            pekerjaan.Text = "";
            noTelpon.Text = "";
            kriteria.Text = "";
            penghasilan.Text = "";
            golDarah.Text = "";
            status.Text = "";
            ket.Text = "";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            PenerimaManfaat pm = new PenerimaManfaat();
            var date = Convert.ToDateTime(tanggalLahir.Text).ToString("yyyy/MM/dd");
            pm.nik = nik.Text;
            pm.kartuKeluarga = kartuKeluarga.Text;
            pm.nama = nama.Text;
            pm.tanggalLahir = date;
            pm.jenisKelamin = jenisKelamin.Text;
            pm.agama = agama.Text;
            pm.kotaKabupaten = kota.Text;
            pm.alamat = alamat.Text;
            pm.pekerjaan = pekerjaan.Text;
            pm.noTelpon = noTelpon.Text;
            pm.kriteria = kriteria.Text;
            pm.penghasilan = penghasilan.Text;
            pm.golDarah = golDarah.Text;
            pm.status = status.Text;
            pm.keterangan = ket.Text;

            dao.InsertData(pm);
            nik.Text = "";
            kartuKeluarga.Text = "";
            nama.Text = "";
            tanggalLahir.Text = "";
            jenisKelamin.Text = "";
            agama.Text = "";
            kota.Text = "";
            alamat.Text = "";
            pekerjaan.Text = "";
            noTelpon.Text = "";
            kriteria.Text = "";
            penghasilan.Text = "";
            golDarah.Text = "";
            status.Text = "";
            ket.Text = "";
            MessageBox.Show("Data Berhasil Ditambahkan");
            InitDataView();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView dr = (DataRowView)dataGrid.SelectedItem;
            nik.Text = dr["NIK"].ToString();
            kartuKeluarga.Text = dr["Nomor KK"].ToString();
            nama.Text = dr["Nama"].ToString();
            tanggalLahir.Text = dr["Tanggal Lahir"].ToString();
            jenisKelamin.Text = dr["Jenis Kelamin"].ToString();
            agama.Text = dr["Agama"].ToString();
            kota.Text = dr["kotaKabupaten"].ToString();
            alamat.Text = dr["Alamat"].ToString();
            pekerjaan.Text = dr["Pekerjaan"].ToString();
            noTelpon.Text = dr["No. Telpon"].ToString();
            kriteria.Text = dr["Kriteria"].ToString();
            penghasilan.Text = dr["Penghasilan"].ToString();
            golDarah.Text = dr["Golongan Darah"].ToString();
            status.Text = dr["Status"].ToString();
            ket.Text = dr["Keterangan"].ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            dao.DeleteData(nik.Text);
            nik.Text = "";
            kartuKeluarga.Text = "";
            nama.Text = "";
            tanggalLahir.Text = "";
            jenisKelamin.Text = "";
            agama.Text = "";
            kota.Text = "";
            alamat.Text = "";
            pekerjaan.Text = "";
            noTelpon.Text = "";
            kriteria.Text = "";
            penghasilan.Text = "";
            golDarah.Text = "";
            status.Text = "";
            ket.Text = "";
            MessageBox.Show("Data Berhasil Dihapus");
            InitDataView();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            PenerimaManfaat pm = new PenerimaManfaat();
            var date = Convert.ToDateTime(tanggalLahir.Text).ToString("yyyy/MM/dd");
            pm.nik = nik.Text;
            pm.kartuKeluarga = kartuKeluarga.Text;
            pm.nama = nama.Text;
            pm.tanggalLahir = date;
            pm.jenisKelamin = jenisKelamin.Text;
            pm.agama = agama.Text;
            pm.kotaKabupaten = kota.Text;
            pm.alamat = alamat.Text;
            pm.pekerjaan = pekerjaan.Text;
            pm.noTelpon = noTelpon.Text;
            pm.kriteria = kriteria.Text;
            pm.penghasilan = penghasilan.Text;
            pm.golDarah = golDarah.Text;
            pm.status = status.Text;
            pm.keterangan = ket.Text;

            dao.UpdateData(pm, pm.nik);
            nik.Text = "";
            kartuKeluarga.Text = "";
            nama.Text = "";
            tanggalLahir.Text = "";
            jenisKelamin.Text = "";
            agama.Text = "";
            kota.Text = "";
            alamat.Text = "";
            pekerjaan.Text = "";
            noTelpon.Text = "";
            kriteria.Text = "";
            penghasilan.Text = "";
            golDarah.Text = "";
            status.Text = "";
            ket.Text = "";
            MessageBox.Show("Data Berhasil Diubah");
            InitDataView();
        }

    }
}
