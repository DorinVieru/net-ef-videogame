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
        public string Country { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        List<Games>? Games { get; set; } // N-N con tabella Games
        public SoftwareHouse() { }
    }
}
