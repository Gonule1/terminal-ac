using System;
using System.Data.SQLite;
using Gtk;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace staj1.Properties
{
    public partial class database : Gtk.Window
    {
        public database() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (entry1.Text == "" | entry3.Text == "" | entry4.Text == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SQLiteConnection baglan = new SQLiteConnection();
                    baglan.ConnectionString = ("Data Source= /bin/database.db/User.sql");
                    baglan.Open();
                    string sql = "SELECT * From Users WHERE kullanicadi=@kullaniciadi AND sifre=@sifre";
                    SQLiteParameter prm = new SQLiteParameter("kullaniciadi", entry3.Text);
                    SQLiteParameter prm1 = new SQLiteParameter("sifre", entry4.Text);
                    SQLiteCommand cmd = new SQLiteCommand(sql, baglan);
                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add(prm1);
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Bağlantı başarılı" + entry3.Text + "");

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

        }
    }
}