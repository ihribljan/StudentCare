using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Nastavnici
    {
        public Nastavnici()
        {
            NastavniciKolegiji = new HashSet<NastavniciKolegiji>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Konzultacije { get; set; }
        public int? DvoraneId { get; set; }
        public string Email { get; set; }

        public virtual Dvorane Dvorane { get; set; }
        public virtual ICollection<NastavniciKolegiji> NastavniciKolegiji { get; set; }
    }
}
