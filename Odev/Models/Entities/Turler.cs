using System;
using System.Collections.Generic;

namespace Odev.Models.Entities
{
    public partial class Turler
    {
        public Turler()
        {
            KitapTurs = new HashSet<KitapTur>();
        }

        public int Id { get; set; }
        public string Ad { get; set; } = null!;

        public virtual ICollection<KitapTur> KitapTurs { get; set; }
    }
}
