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
    public partial class FormLogin : Form
    {
        string nama;
        string pass;
        public FormLogin()
        {
            InitializeComponent();
        }

      
       
        private void login(object sender, EventArgs e)
        {
            this.nama = user.Text;
            this.pass = passwud.Text;
            if (this.nama != null && this.pass == "pbo123")
            {
                MenuUtama utama = new MenuUtama();
                utama.Show();
                this.Hide();
                MessageBox.Show("Anda berhasil login");
            }
            else if (user.Text == "" || passwud.Text == "")
            {
                MessageBox.Show("Anda belum mengisi form login");
            }
            else
            {
                MessageBox.Show("Username atau Password Salah ");
            }
           
            
        }

        private void username(object sender, EventArgs e)
        {

        }

        private void password(object sender, EventArgs e)
        {
            
        }
    }
}
