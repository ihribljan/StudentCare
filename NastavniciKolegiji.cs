using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class NastavniciKolegiji
    {
        public int Id { get; set; }
        public int NastavniciId { get; set; }
        public int KolegijiId { get; set; }

        public virtual Kolegiji Kolegiji { get; set; }
        public virtual Nastavnici Nastavnici { get; set; }
    }
}
