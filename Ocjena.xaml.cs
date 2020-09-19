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
    /// Interaction logic for Ocjene.xaml
    /// </summary>
    public partial class Ocjena : Window
    {
        public Ocjena()
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

                var studenti = from i in db.Studenti
                              select i;

                if (studenti != null)
                {
                    List<Studenti> listaStudenata = new List<Studenti>();

                    foreach (var i in studenti)
                    {
                        listaStudenata.Add(i);
                    }

                    cmbStudent.ItemsSource = listaStudenata;
                    cmbStudent.DisplayMemberPath = "Prezime";
                    cmbStudent.SelectedValuePath = "Id";
                }
            }
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Trace.WriteLine("selection");

            using (var db = new StudentCareContext())
            {
                var jmbag = from it in db.Studenti
                            where cmbStudent.SelectedValue.ToString() == it.Id.ToString()
                            select it;

                if (jmbag != null)
                {
                    foreach (var i in jmbag)
                    {
                        txtJMBAG.Text = i.Jmbag;
                    }
                }
            }
        }

        private void cmbKolegij_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new StudentCareContext())
            {
                var naziv = from i in db.Kolegiji
                            join ii in db.Provjere on i.Id equals ii.KolegijiId
                            where ii.KolegijiId == int.Parse(cmbKolegij.SelectedValue.ToString())
                            select ii;

                if (naziv != null)
                {
                    List<Provjere> listaProvjera = new List<Provjere>();

                    foreach (var itt in naziv)
                    {
                        listaProvjera.Add(itt);
                    }

                    cmbNaziv.ItemsSource = listaProvjera;
                    cmbNaziv.DisplayMemberPath = "Naziv";
                    cmbNaziv.SelectedValuePath = "Id";
                }
            }
        }

        private void btnRaspored_Click(object sender, RoutedEventArgs e)
        {
            Raspored raspored = new Raspored();
            raspored.Show();
            this.Hide();
        }

        private void btnProvjere_Click(object sender, RoutedEventArgs e)
        {
            Provjera provjera = new Provjera();
            provjera.Show();
            this.Hide();
        }

        public void dodajOcjenu(int kolegij, int student, int provjera, string bodovi, string ocjena, string napomena)
        {
            using (var db = new StudentCareContext())
            {
                Ocjene ocjene = new Ocjene();

                ocjene.KolegijiId = kolegij;
                ocjene.StudentiId = student;
                ocjene.ProvjereId = provjera;
                ocjene.Bodovi = bodovi;
                ocjene.Ocjena = ocjena;
                ocjene.Napomena = napomena;

                db.Ocjene.Add(ocjene);
                db.SaveChanges();
            }
        }

        private void btnSpremi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dodajOcjenu(int.Parse(cmbKolegij.SelectedValue.ToString()), int.Parse(cmbStudent.SelectedValue.ToString()), int.Parse(cmbNaziv.SelectedValue.ToString()), txtBodovi.Text, txtOcjena.Text, txtNapomena.Text);
                //OcistiFormu();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        public void OcistiFormu()
        {
            cmbKolegij.Text = "";
            cmbStudent.Text = "";
            txtJMBAG.Clear();
            txtBodovi.Clear();
            txtNapomena.Clear();
            txtOcjena.Clear();
        }
    }
}
