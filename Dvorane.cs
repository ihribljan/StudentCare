using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Dvorane
    {
        public Dvorane()
        {
            Nastavnici = new HashSet<Nastavnici>();
            Provjere = new HashSet<Provjere>();
            Rasporedi = new HashSet<Rasporedi>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public short Kapacitet { get; set; }
        public string Zgrada { get; set; }
        public string Kat { get; set; }
        public string Krilo { get; set; }

        public virtual ICollection<Nastavnici> Nastavnici { get; set; }
        public virtual ICollection<Provjere> Provjere { get; set; }
        public virtual ICollection<Rasporedi> Rasporedi { get; set; }
    }
}
