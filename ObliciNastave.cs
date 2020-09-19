using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class ObliciNastave
    {
        public ObliciNastave()
        {
            Rasporedi = new HashSet<Rasporedi>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Rasporedi> Rasporedi { get; set; }
    }
}
