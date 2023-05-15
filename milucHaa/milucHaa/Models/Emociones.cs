using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace milucHaa.Models
{
    public class Emociones
    {
        [PrimaryKey,AutoIncrement]

        public int IdEmocion { get; set; }

        public string Emocion { get; set; }

        public int Toques { get; set; }

        public string Imagen { get; set; }
    }
}
