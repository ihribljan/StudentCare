using System;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class Ocjene
    {
        public int Id { get; set; }
        public int KolegijiId { get; set; }
        public int StudentiId { get; set; }
        public int ProvjereId { get; set; }
        public string Bodovi { get; set; }
        public string Ocjena { get; set; }
        public string Napomena { get; set; }
    }
}
