using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Rasporedi
    {
        public int Id { get; set; }
        public int KolegijiId { get; set; }
        public int ObliciNastaveId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int DvoraneId { get; set; }
        public string Napomena { get; set; }

        public virtual Dvorane Dvorane { get; set; }
        public virtual Kolegiji Kolegiji { get; set; }
        public virtual ObliciNastave ObliciNastave { get; set; }
    }
}
