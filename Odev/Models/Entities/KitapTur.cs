using System;
using System.Collections.Generic;

namespace Odev.Models.Entities
{
    public partial class KitapTur
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public int TurId { get; set; }

        public virtual Kitaplar Kitap { get; set; } = null!;
        public virtual Turler Tur { get; set; } = null!;
    }
}
