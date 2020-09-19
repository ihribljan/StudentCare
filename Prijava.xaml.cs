using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.Diagnostics;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Prijava.xaml
    /// </summary>
    public partial class Prijava : Window
    {
        public Prijava()
        {
            InitializeComponent();
        }

        public bool Autentifikacija(string korisnik, string lozinka)
        {
            using (var db = new StudentCareContext())
            {
                var provjeraKorisnika = from item in db.Nastavnici
                                        where korisnik == item.KorisnickoIme
                                        && lozinka == item.Lozinka
                                        select item;

                Trace.WriteLine("id: ", provjeraKorisnika.ToString());

                if (provjeraKorisnika != null)
                {
                    foreach (var it in provjeraKorisnika)
                    {
                        Trace.WriteLine("aa: " + it.KorisnickoIme);
                        return true;
                    }
                }             
            }

            return false;
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("podaci: " + txtKorisnickoIme.Text.ToString() + " " + txtLozinka.Text.ToString());

            if (Autentifikacija(txtKorisnickoIme.Text.ToString(), txtLozinka.Text.ToString()))
            {
                this.Hide();
                Raspored raspored = new Raspored();
                raspored.Show();
            }
            else
            {
                MessageBox.Show("Pogrešni podaci!");
            }
        }
    }
}
