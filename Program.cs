using System;
using Gtk;

using System.Windows.Forms;
using System.Data;
using Application = Gtk.Application;
using staj1.Properties;
using System.Web.UI;

namespace staj1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow kayit = new MainWindow();
            kayit.Show();
            Application.Run();
            

        }

    }
}