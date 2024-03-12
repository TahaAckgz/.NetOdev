using System;
using System.Collections.Generic;

namespace Odev.Models.Entities
{
    public partial class Yazarlar
    {
        public Yazarlar()
        {
            Kitaplars = new HashSet<Kitaplar>();
        }

        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public short? DogumYili { get; set; }
        public string? DogumYeri { get; set; }
        /// <summary>
        /// Kadın/Erkek K/E
        /// </summary>
        public string? Cinsiyet { get; set; }

        public virtual ICollection<Kitaplar> Kitaplars { get; set; }
    }
}
