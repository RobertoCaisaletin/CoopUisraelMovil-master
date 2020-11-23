using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using CoopUisraelSQlite.Models;
namespace CoopUisraelSQlite.Models
{
    public class Credito
    {
        
            [PrimaryKey, AutoIncrement]

            public int Id { get; set; }
            [MaxLength(255)]

            public string Nombres { get; set; }
            [MaxLength(255)]

            public string Apellidos { get; set; }
            [MaxLength(255)]

            public string Direccion { get; set; }
            [MaxLength(255)]

            public string Monto { get; set; }
            [MaxLength(255)]

            public string Plazo { get; set; }
        public string FullName => $"{Nombres} {Apellidos}";
    }
}
