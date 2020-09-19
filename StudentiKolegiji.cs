using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class StudentiKolegiji
    {
        public int Id { get; set; }
        public int StudentiId { get; set; }
        public int KolegijiId { get; set; }

        public virtual Kolegiji Kolegiji { get; set; }
        public virtual Studenti Studenti { get; set; }
    }
}
