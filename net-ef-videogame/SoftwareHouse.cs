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
        [Key] public int SoftwareHouseId { get; set; }
        public string? Name { get; set; }
        List<Games>? Games { get; set; } // N-N con tabella Games
        public SoftwareHouse() { }
    }
}
