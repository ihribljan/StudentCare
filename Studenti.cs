using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Studenti
    {
        public Studenti()
        {
            StudentiKolegiji = new HashSet<StudentiKolegiji>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbag { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public virtual ICollection<StudentiKolegiji> StudentiKolegiji { get; set; }
    }
}
