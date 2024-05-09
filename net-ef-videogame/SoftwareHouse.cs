using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("software_house")]
    [Index(nameof(SoftwareHouseId), IsUnique = true)]
    public class SoftwareHouse
    {
        [Key] public long SoftwareHouseId { get; set; }
        public string Name { get; set; }
        [Column("tax_id")]
        public string TaxId { get; set; }
        public string City { get; set; }
        List<Games>? Games { get; set; } // N-N con tabella Games
        public string Country { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        // COSTRUTTORE VUOTO
        public SoftwareHouse() { }

        // COSTRUTTORE
        public SoftwareHouse(string name, string taxId, string city, string country)
        {
            this.Name = name;
            this.TaxId = taxId;
            this.City = city;
            this.Country = country;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}
