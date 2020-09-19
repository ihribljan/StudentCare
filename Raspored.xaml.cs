using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Raspored.xaml
    /// </summary>
    public partial class Raspored : Window
    {
        public Raspored()
        {
            InitializeComponent();
            GetData();
        }

        public void GetData()
        {
            using (var db = new StudentCareContext())
            {
                var kolegiji = from it in db.Kolegiji
                               select it;

                if (kolegiji != null)
                {
                    List<Kolegiji> listaKolegija = new List<Kolegiji>();

                    foreach (var it in kolegiji)
                    {
                        listaKolegija.Add(it);
                    }

                    cmbKolegij.ItemsSource = listaKolegija;
                    cmbKolegij.DisplayMemberPath = "Naziv";
                    cmbKolegij.SelectedValuePath = "Id";
                }

                var dvorane = from i in db.Dvorane
                              select i;

                if (dvorane != null)
                {
                    List<Dvorane> listaDvorana = new List<Dvorane>();

                    foreach (var i in dvorane)
                    {
                        listaDvorana.Add(i);
                    }

                    cmbDvorana.ItemsSource = listaDvorana;
                    cmbDvorana.DisplayMemberPath = "Naziv";
                    cmbDvorana.SelectedValuePath = "Id";
                }

                var obliciNastave = from itt in db.ObliciNastave
                                    select itt;

                if (obliciNastave != null)
                {
                    List<ObliciNastave> listaObliciNastave = new List<ObliciNastave>();

                    foreach (var itt in obliciNastave)
                    {
                        listaObliciNastave.Add(itt);
                    }

                    cmbOblikNastave.ItemsSource = listaObliciNastave;
                    cmbOblikNastave.DisplayMemberPath = "Naziv";
                    cmbOblikNastave.SelectedValuePath = "Id";
                }
            }
        }

        public void dodajRaspored(int kolegij, int oblikNastave, DateTime datumOd, 
            DateTime datumDo, int dvorana, string napomena)
        {
            using (var db = new StudentCareContext())
            {
                Rasporedi rasporedi = new Rasporedi();

                rasporedi.KolegijiId = kolegij;
                rasporedi.ObliciNastaveId = oblikNastave;
                rasporedi.DatumOd = datumOd;
                rasporedi.DatumDo = datumDo;
                rasporedi.DvoraneId = dvorana;
                rasporedi.Napomena = napomena;

                db.Rasporedi.Add(rasporedi);
                db.SaveChanges();
            }
        }

        private void btnOcjene_Click(object sender, RoutedEventArgs e)
        {
            Ocjena ocjena = new Ocjena();
            ocjena.Show();
            this.Hide();
        }

        private void btnProvjere_Click(object sender, RoutedEventArgs e)
        {
            Provjera provjera = new Provjera();
            provjera.Show();
            this.Hide();
        }

        private void btnSpremi_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("test: ", cmbKolegij.GetType().ToString());

            dodajRaspored(int.Parse(cmbKolegij.SelectedValue.ToString()), int.Parse(cmbOblikNastave.SelectedValue.ToString()), DateTime.Parse(dtpDatumOd.SelectedDate.ToString()), DateTime.Parse(dtpDatumDo.SelectedDate.ToString()), int.Parse(cmbDvorana.SelectedValue.ToString()), txtNapomena.Text);

            OcistiFormu();
        }

        private void cmbKolegij_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void OcistiFormu()
        {
            cmbKolegij.Text = "";
            cmbDvorana.Text = "";
            cmbOblikNastave.Text = "";
            dtpDatumDo.SelectedDate = null;
            dtpDatumOd.SelectedDate = null;
            txtNapomena.Clear();
        }
    }
}
