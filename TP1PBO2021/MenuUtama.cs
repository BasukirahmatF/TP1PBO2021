using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1PBO2021
{
    public partial class MenuUtama : Form
    {
        List<dataBarang> barang = new List<dataBarang>();

        string jenis = "";
        int minharga;
        int maxharga;

       
        public MenuUtama()
        {
            InitializeComponent();
            creatListbrg();
            filterProses(this.jenis,this.minharga,this.maxharga);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox value = (ComboBox)sender;
            value.DropDownStyle = ComboBoxStyle.DropDownList;
            this.jenis = value.SelectedItem.ToString().ToLower();
      
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox value = (ComboBox)sender;
            value.DropDownStyle = ComboBoxStyle.DropDownList;
            ambilHarga(value.SelectedItem.ToString().ToLower());
           
        }
        private void ambilHarga(string value)
        {
            if (value == "100rb - 200rb")
            {
                this.minharga = 100000;
                this.maxharga = 200000;
            }
            else if (value == "200rb - 500rb")
            {
                this.minharga = 200000;
                this.maxharga = 500000;
            }
            else if (value == "500rb - 1jt")
            {
                this.minharga = 500000;
                this.maxharga = 1000000;
            }
        }

        void creatListbrg()
        {

            this.barang.Add(new dataBarang("Drone", 1000000, "5", "Elektronik"));
            this.barang.Add(new dataBarang("PC", 900000, "1", "Elektronik"));
            this.barang.Add(new dataBarang("Bakmie", 200000, "2", "Makanan"));
            this.barang.Add(new dataBarang("Bakso", 150000, "3", "Makanan"));
            this.barang.Add(new dataBarang("Denim", 100000, "4", "Baju"));

           
            
        }


        Panel addPanel(string nama, string harga, string idbarang, string jenis)
        {

            Panel pnl = new Panel();
            pnl.Size = new Size(138, 142);
            pnl.BackColor = System.Drawing.Color.MediumTurquoise;
            Button btn = addButton(idbarang);
            btn.Text = "Beli";
            Label brg = addLabel(nama);
            brg.Text = nama;
            Label hrg = addlblharga(harga);
            hrg.Text = harga;
            pnl.Controls.Add(brg);
            pnl.Controls.Add(btn);
            pnl.Controls.Add(hrg);
            return pnl;
        }
        Label addLabel(string nama)
        {
            Label pnl = new Label();
            pnl.Size = new Size(78, 13);
            pnl.Location = new System.Drawing.Point(31, 85);
            pnl.ForeColor = System.Drawing.Color.Black;
            return pnl;
        }
        Button addButton(string id)
        {

            Button pnl = new Button();
            pnl.Name = id;
            pnl.Size = new Size(68, 28);
            pnl.Location = new System.Drawing.Point(34, 111);
            pnl.BackColor = System.Drawing.Color.White;

            pnl.Click += new System.EventHandler(this.btn_Detail);
            return pnl;


        }
        private void btn_Detail(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Form1 kedua = new Form1(button.Name.ToString());
            kedua.Show();
            this.Hide();

        }
        Label addlblharga(string harga)
        {
            Label hrg = new Label();
            hrg.Size = new Size(66, 13);
            hrg.Location = new System.Drawing.Point(43, 98);
            hrg.ForeColor = System.Drawing.Color.Black;
            return hrg;
        }
        void filterProses(string jenis, int minharga, int maxharga)
        {
            Temp_produk.Controls.Clear();
            foreach (var data in this.barang){
                
               Panel pnl = addPanel(data.getNamaBarang, data.getHarga.ToString(), data.getIdbarang, data.getJenis);
                if (data.getJenis.ToLower() == this.jenis.ToLower()) {
                if (data.getHarga >= minharga && data.getHarga <= maxharga){
                       
                        Temp_produk.Controls.Add(pnl);
                    }else if (minharga == 0){
                        Temp_produk.Controls.Add(pnl);
                    }
                }
                else if (this.jenis == "")
                {
                    if (data.getHarga >= minharga && data.getHarga <= maxharga)
                    {
                        Temp_produk.Controls.Add(pnl);
                    }
                    else if(minharga == 0)
                    {
                        Temp_produk.Controls.Add(pnl);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterProses(this.jenis, this.minharga, this.maxharga);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLogin klr = new FormLogin();
            this.Hide();
            klr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://shopee.co.id/br.store98");
        }
    }
    class dataBarang
    {
        public dataBarang(string nama, int harga, string idbarang, string jenis)
        {
            getNamaBarang = nama;
            getHarga = harga;
            getIdbarang = idbarang;
            getJenis = jenis;
        }
        public string getNamaBarang
        {
            get; set;
        }
        public int getHarga
        {
            get; set;
        }
        public string getIdbarang
        {
            get; set;
        }
        public string getJenis
        {
            get; set;
        }
    }
}
