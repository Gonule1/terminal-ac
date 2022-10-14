using System;
using Gtk;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.Text;
using Application = Gtk.Application;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SQLite.Generic;
using Button = Gtk.Button;
using System.Timers;
using System.Threading;
using System.Web.UI;

namespace staj1.Properties
{
    public partial class MainWindow : Gtk.Window
    {
        public bool IsMdiContainer { get; }

        public MainWindow() :
                         base(Gtk.WindowType.Toplevel)
        {
            this.Build();


        }
        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            
            Application.Quit();
            a.RetVal = true;
        }
        


        private void OnButton2Clicked(object sender, EventArgs e)
        {

            MessageBox.Show("Kaydınız yapılıyor.","BİLGİ", MessageBoxButtons.OK,MessageBoxIcon.Information);

            if (entry2.Text == "" | entry3.Text == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SQLiteConnection baglan = new SQLiteConnection();
                    baglan.ConnectionString = ("Data Source= Users.sql");
                    baglan.Open();
                    string sql = "SELECT * From Kullanicilar WHERE kullanicadi=@kullaniciadi AND sifre=@sifre";
                    SQLiteParameter prm = new SQLiteParameter("kullaniciadi", entry2.Text);
                    SQLiteParameter prm1 = new SQLiteParameter("sifre", entry3.Text);
                    SQLiteCommand cmd = new SQLiteCommand(sql, baglan);
                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add(prm1);
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Bağlantı başarılı" + entry2.Text + "");

                      
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            this.Hide();

        }

        
        private void OnButton1Clicked(object sender, EventArgs e)
        {

            if (entry2.Text == "" | entry3.Text == "" )
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SQLiteConnection baglan = new SQLiteConnection();
                    baglan.ConnectionString = ("Data Source=/bin/database.db/ Users.sql");
                    baglan.Open();
                    string sql = "SELECT * From Users WHERE kullanicadi=@kullaniciadi AND sifre=@sifre";
                    SQLiteParameter prm = new SQLiteParameter("kullaniciadi", entry2.Text);
                    SQLiteParameter prm1 = new SQLiteParameter("sifre", entry3.Text);
                    SQLiteCommand cmd = new SQLiteCommand(sql, baglan);
                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add(prm1);
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                       
                        MessageBox.Show("Bağlantı başarılı" + entry2.Text + "");

                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            this.Hide();

        }
    }



}





