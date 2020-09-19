using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Provjera.xaml
    /// </summary>
    public partial class Provjera : Window
    {
        public Provjera()
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

                var tipProvjere = from itt in db.TipoviProvjera
                                  select itt;

                if (tipProvjere != null)
                {
                    List<TipoviProvjera> listaTipoviProvjera = new List<TipoviProvjera>();

                    foreach (var itt in tipProvjere)
                    {
                        listaTipoviProvjera.Add(itt);
                    }

                    cmbTipProvjere.ItemsSource = listaTipoviProvjera;
                    cmbTipProvjere.DisplayMemberPath = "Naziv";
                    cmbTipProvjere.SelectedValuePath = "Id";
                }
            }
        }

        private void btnRaspored_Click(object sender, RoutedEventArgs e)
        {
            Raspored raspored = new Raspored();
            raspored.Show();
            this.Hide();
        }

        private void btnOcjene_Click(object sender, RoutedEventArgs e)
        {
            Ocjena ocjena = new Ocjena();
            ocjena.Show();
            this.Hide();
        }

        public void dodajProvjeru(int kolegij, DateTime datum, int dvorana, int tipProvjere, string naziv)
        {
            using (var db = new StudentCareContext())
            {
                Provjere provjere = new Provjere();

                provjere.KolegijiId = kolegij;
                provjere.Datum = datum;
                provjere.DvoraneId = dvorana;
                provjere.TipoviProvjeraId = tipProvjere;
                provjere.Naziv = naziv;

                db.Provjere.Add(provjere);
                db.SaveChanges();
            }
        }

        private void btnSpremi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dodajProvjeru(int.Parse(cmbKolegij.SelectedValue.ToString()), DateTime.Parse(dtpDatum.SelectedDate.ToString()), int.Parse(cmbDvorana.SelectedValue.ToString()), int.Parse(cmbTipProvjere.SelectedValue.ToString()), txtNaziv.Text);
                OcistiFormu();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        public void OcistiFormu()
        {
            cmbKolegij.Text = "";
            cmbDvorana.Text = "";
            cmbTipProvjere.Text = "";
            dtpDatum.SelectedDate = null;
            txtNaziv.Clear();
        }
    }
}
