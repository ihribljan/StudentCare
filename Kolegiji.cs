using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Kolegiji
    {
        public Kolegiji()
        {
            NastavniciKolegiji = new HashSet<NastavniciKolegiji>();
            Provjere = new HashSet<Provjere>();
            Rasporedi = new HashSet<Rasporedi>();
            StudentiKolegiji = new HashSet<StudentiKolegiji>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public short? Ects { get; set; }

        public virtual ICollection<NastavniciKolegiji> NastavniciKolegiji { get; set; }
        public virtual ICollection<Provjere> Provjere { get; set; }
        public virtual ICollection<Rasporedi> Rasporedi { get; set; }
        public virtual ICollection<StudentiKolegiji> StudentiKolegiji { get; set; }
    }
}
