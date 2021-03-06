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
    public partial class Form1 : Form
    {
        List<dataBarang> barang = new List<dataBarang>();
        public Form1(string id )
        {
            InitializeComponent();
            creatListbrg();
            
            foreach (var data in barang)
            {
                if (data.getIdbarang.ToString() == id)
                {
                    Panel pnl = addPanel(data.getNamaBarang,data.getHarga.ToString(),data.getIdbarang,data.getJenis);
                    Temp_produk.Controls.Add(pnl);
                  
                }
                
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
        Label addlblharga(string harga)
        {
            Label hrg = new Label();
            hrg.Size = new Size(66, 13);
            hrg.Location = new System.Drawing.Point(43, 98);
            hrg.ForeColor = System.Drawing.Color.Black;
            return hrg;
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

           
            return pnl;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuUtama klr = new MenuUtama();
            this.Hide();
            klr.Show();
        }
    }
}
