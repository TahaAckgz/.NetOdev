using System;
using System.Collections.Generic;

namespace Odev.Models.Entities
{
    public partial class Kitaplar
    {
        public Kitaplar()
        {
            KitapTurs = new HashSet<KitapTur>();
        }

        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public string? Ozet { get; set; }
        public string? Foto { get; set; }
        public ushort? SayfaSayisi { get; set; }
        public int YayineviId { get; set; }
        public int YazarId { get; set; }

        public virtual Yayinevleri Yayinevi { get; set; } = null!;
        public virtual Yazarlar Yazar { get; set; } = null!;
        public virtual ICollection<KitapTur> KitapTurs { get; set; }
    }
}
