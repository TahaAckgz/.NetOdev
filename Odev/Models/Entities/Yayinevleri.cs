using System;
using System.Collections.Generic;

namespace Odev.Models.Entities
{
    public partial class Yayinevleri
    {
        public Yayinevleri()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int Id { get; set; }
        public string Ad { get; set; } = null!;

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
