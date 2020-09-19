using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Provjere
    {
        public int Id { get; set; }
        public int KolegijiId { get; set; }
        public DateTime? Datum { get; set; }
        public int DvoraneId { get; set; }
        public int TipoviProvjeraId { get; set; }
        public string Ocjena { get; set; }
        public string Naziv { get; set; }

        public virtual Dvorane Dvorane { get; set; }
        public virtual Kolegiji Kolegiji { get; set; }
        public virtual TipoviProvjera TipoviProvjera { get; set; }
    }
}
