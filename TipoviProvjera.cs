using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class TipoviProvjera
    {
        public TipoviProvjera()
        {
            Provjere = new HashSet<Provjere>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Provjere> Provjere { get; set; }
    }
}
